﻿namespace Oficina.Dominio
{
    public class Modelo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Marca Marca { get; set; }
    }
}