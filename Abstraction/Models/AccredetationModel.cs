﻿using Abstraction.Entities.Enums;
using Abstraction.Entities;

namespace Abstraction.Models;

public class AccredetationModel
{
    public Status Status { get; set; }

    public DateOnly Expires { get; set; }
}
