using juego_impostor_backend.Features.IniciarPartida.Application.DTOs;
using juego_impostor_backend.Features.IniciarPartida.Application.Interfaces;
using juego_impostor_backend.Features.IniciarPartida.Infrastructure;
using juego_impostor_backend.Shared.Persistence;

namespace juego_impostor_backend.Features.IniciarPartida.Application.Services
{
    public class ConfiguracionService(IUnitOfWork unitOfWork) : IConfiguracionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private static readonly Random random = new();

        public string[] ElegirImpostores(configuracion configuracion)
        {
            // Elegimos los impostores al azar. tenemos que elegir desde el 1 hasta la CantImpostores.
            int[] impostoresSeleccionados = new int[configuracion.CantImpostores];
            string[] nombresImpostores = new string[configuracion.CantImpostores];

            // Si PalabraSecretaNueva es null or Empty, el jugador N1 puede ser impostor tranquilamente. Por ende empezamos a elegir desde el 1.
            // Entendiendo que el jugador N1 elije la frase secreta, no puede ser impostor el mismo porque ya conoce la frase. Por ende empezamos a elegir desde el 2.
            int indexInit = string.IsNullOrEmpty(configuracion.PalabraSecretaNueva) ? 1 : 2;

            // Elegimos los numeros de jugador que van a ser los impostores.
            for (int i = 0; i < configuracion.CantImpostores; i++)
            {
                int randomIndex = random.Next(indexInit, configuracion.Jugadores.Count());

                while (impostoresSeleccionados.Contains(randomIndex))
                    randomIndex = random.Next(indexInit, configuracion.Jugadores.Count());

                impostoresSeleccionados[i] = randomIndex;
            }

            for (int i = 0; i < configuracion.CantImpostores; i++)
                nombresImpostores[i] = configuracion.Jugadores[impostoresSeleccionados[i]];

            return nombresImpostores;
        }

        public string ElegirPalabraSecreta(configuracion configuracion)
        {
            // Si PalabraSecretaNueva es null or Empty elegir una palabra secreta al azar de la lista de palabras.
            // Si no es null or Empty, usar la PalabraSecretaNueva que ingreso el usuario.

            List<string> Todas = _unitOfWork.PalabrasSecretas.ObtenerTodasAsync().Result;
            string palabraSecreta = string.Empty;

            if (string.IsNullOrEmpty(configuracion.PalabraSecretaNueva))
            {
                // Elegimos PalabraSecreta al azar de la lista de frases y palabras.
                int randomIndex = random.Next(0, Todas.Count());
                palabraSecreta = Todas[randomIndex].ToString();
            }
            else
            {
                // FALTA agregarla en db.
                // Agregar la nueva palabra a la lista de palabras.
                Todas.Add(configuracion.PalabraSecretaNueva);
                palabraSecreta = configuracion.PalabraSecretaNueva;
            }

            return palabraSecreta;
        }

        public List<string> TraerTodasPalabrasSecretas()
        {
            List<string> Todas = _unitOfWork.PalabrasSecretas.ObtenerTodasAsync().Result;
            return Todas;
        }
    }
}
