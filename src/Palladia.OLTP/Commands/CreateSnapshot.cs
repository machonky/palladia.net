﻿using Memstate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Palladia.OLTP.Commands
{
    public class CreateSnapshot : Command<AuthorisationModel>
    {
        private readonly Stream output;

        public CreateSnapshot(Stream output)
        {
            this.output = output;
        }

        public override void Execute(AuthorisationModel model)
        {

        }
    }
}