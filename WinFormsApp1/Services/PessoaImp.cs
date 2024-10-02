using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto01.serviço;
using System.Data;
using WebApplication1.Services;

public class PessoaImp : IPessoaService
{
    private readonly IDbConnection _dbConnection;

    public PessoaImp(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<IEnumerable<PessoaSalarioDto>> ObterSalariosAsync()
    {
        const string query = @"SELECT pessoa_id, nome, salario FROM pessoa_salario";

        try
        {
            var salarios = await _dbConnection.QueryAsync<PessoaSalarioDto>(query);
            return salarios;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao obter os salários", ex);
        }
    }

    
    public async Task CalcularSalariosAsync()
    {
        try
        {
            const string storedProcedure = "sp_CalcularSalarios";
            await _dbConnection.ExecuteAsync(storedProcedure, commandType: CommandType.StoredProcedure);
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao calcular os salários", ex);
        }
    }
