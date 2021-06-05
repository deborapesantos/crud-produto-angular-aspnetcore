using Solution_CrudProduto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Data.Repository
{
    public class ProdutoRepository : BaseDBRepository<Produto>
    {
        public ProdutoRepository(BaseContext pContext) : base(pContext)
        {

        }
    }
}
