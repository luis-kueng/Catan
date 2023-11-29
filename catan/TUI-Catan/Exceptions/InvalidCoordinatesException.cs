namespace Catan.Exceptions {
    public class InvalidCoordinatesException : Exception {
        public InvalidCoordinatesException(string message) : base(message) {
        }

        public InvalidCoordinatesException(string message, Exception innerExcption) : base(message, innerExcption) {
        }

        public InvalidCoordinatesException() {
        }
    }
}
