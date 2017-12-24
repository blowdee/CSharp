using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Models
{
    public class Player
    {
        [Required]
        public string Name { get; set; }
        public int Wins { get; set; }
        public int Games { get; set; }
    }
}