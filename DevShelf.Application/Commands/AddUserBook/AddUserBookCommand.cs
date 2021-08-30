using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.AddUserBook
{
    public class AddUserBookCommand : Command<Unit>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
        public override void Validate()
        {
            
        }
    }
}
