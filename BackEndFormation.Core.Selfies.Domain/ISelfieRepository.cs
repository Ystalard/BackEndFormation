﻿using BackEndFormation.Core.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEndFormation.Core.Selfies.Domain
{
    public interface ISelfieRepository: IRepository
    {
        ICollection<Selfie> GetAll();
    }
}
