﻿using WebApiHW_8._08._22.Interfaces;


namespace WebApiHW_8._08._22.Entity;

public class Employer : IPerson
{
    public int Id { get; set; }
    public string Name { get; set; }
}
