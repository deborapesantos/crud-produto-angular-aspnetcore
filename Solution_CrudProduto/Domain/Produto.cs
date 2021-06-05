using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Domain
{
    public class Produto
    {
        public Int64 ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal ValorVenda { get; set; }
        public string PathImagem { get; set; }
    }
}
