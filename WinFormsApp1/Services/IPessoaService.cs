using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebApplication1.Services;

public interface IPessoaService
{
    Task<IEnumerable<PessoaSalarioDto>> ObterSalariosAsync();
    Task CalcularSalariosAsync();
    Task<IEnumerable<Pessoa>> ObterPessoasAsync();
    Task CriarPessoaAsync(Pessoa pessoa);
    Task AtualizarPessoaAsync(int id, Pessoa pessoaAtualizada);
    Task ExcluirPessoaAsync(int id);
}


