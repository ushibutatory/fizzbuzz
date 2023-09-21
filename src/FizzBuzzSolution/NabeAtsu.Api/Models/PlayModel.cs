using System.ComponentModel.DataAnnotations;

namespace NabeAtsu.Api.Models
{
    public class PlayModel
    {
        [Required]
        public string Start { get; set; } = string.Empty;

        [Required]
        public string Count { get; set; } = string.Empty;

        public class Error
        {
            public string Message { get; set; }
            public PlayModel Model { get; set; }

            public Error(string message, PlayModel model)
            {
                Message = message;
                Model = model;
            }
        }
    }
}
