using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.models;
public class Pessoa
{
    public int PessoaId { get; set; }
    public string Nome { get; set; }
    public int CargoId { get; set; }
    public Cargo Cargo { get; set; }
}

