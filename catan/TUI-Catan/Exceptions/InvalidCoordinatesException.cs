using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Exceptions {
    public class InvalidCoordinatesException : Exception {

        public InvalidCoordinatesException(string message) : base(message) { }

        public InvalidCoordinatesException(string message, Exception innerExcption) : base(message, innerExcption) { }

        public InvalidCoordinatesException() {
        }
    }
}
