namespace Catan.Exceptions {
    public class PLayersListEmptyException : Exception {
        public PLayersListEmptyException(string message) : base(message) {
        }

        public PLayersListEmptyException(string message, Exception innerException) : base(message, innerException) {
        }

        public PLayersListEmptyException() {
        }
    }
}
