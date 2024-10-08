﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Application.Commands.Tours
{
    public class DeleteTourCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
