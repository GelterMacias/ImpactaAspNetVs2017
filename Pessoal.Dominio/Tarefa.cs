﻿namespace Pessoal.Dominio
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Prioridade { get; set; }
        public bool Concluida { get; set; }
        public string Observacoes { get; set; }
    }
}
