using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PortalCompras.Produtos.boundedContext.Application.ViewModels
{
    /// <summary>
    /// Esta é uma classe que serve como objeto de passagem de dados entre a aplicação e o dominio.
    /// </summary>
    public class ProdutoViewModel
    {

        public Guid Id { get; set; }
        
        public string nome { get;  set; }

        public string descricao { get;  set; }

        /// <summary>
        /// Define se o produto esta ativo ou não
        /// </summary>
        /// <example>true</example>
        public bool ativo { get;  set; }

        /// <summary>
        /// Define o valor do produto
        /// </summary>
        /// <example>1.500</example>
        public decimal valor { get;  set; }

        /// <summary>
        /// Define a quantidade de estoque disponivel do produto
        /// </summary>
        /// <example>1.500</example>
        public int estoque { get;  set; }

        /// <summary>
        /// Retorna a Data e hora que o produto foi cadastrado
        /// </summary>
        /// <example>2022-03-28T15:35:32.384Z</example>
        public DateTime dataCadastro { get; set; }

    }



}
