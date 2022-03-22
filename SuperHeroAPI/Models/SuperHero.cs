﻿using System;
namespace SuperHeroAPI.Models
{
    public class SuperHero
    {
        //This is the constructor
        public SuperHero(){}

        //Properties ...
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Place { get; set; } = string.Empty;

    }
}
