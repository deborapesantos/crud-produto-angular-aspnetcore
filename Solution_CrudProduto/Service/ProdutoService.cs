using Microsoft.AspNetCore.Authentication;
using Solution_CrudProduto.Data;
using Solution_CrudProduto.Data.Repository;
using Solution_CrudProduto.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solution_CrudProduto.Service
{
    public class ProdutoService
    {

        private readonly BaseContext _baseContext;
        private readonly ProdutoRepository _repository;

        public ProdutoService(BaseContext pBaseContext)
        {
            _baseContext = pBaseContext;
            _repository = new ProdutoRepository(_baseContext);
        }

        /// <summary>
        /// Busca uma lista de registros na tabela Produto com base em um filtro
        /// </summary>
        /// <param name="pFilter"></param>
        public List<Produto> GetAllProdutos(Produto pFilter, ref Result resultado)
        {
            List<Produto> produtos = new List<Produto>();

            try
            {
                produtos = _repository.GetAll(x=> string.IsNullOrEmpty(pFilter.Nome) ||  
                                                                        x.Nome.ToUpper().Contains(pFilter.Nome.ToUpper())).ToList();
            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);
                return null;
            }

            return produtos;
        }

        /// <summary>
        /// Busca um registro na tabela Produto com base em um filtro
        /// </summary>
        /// <param name="pFilter"></param>
        public Produto GetProduto(Produto pFilter, ref Result resultado)
        {
            Produto produto = new Produto();

            try
            {
                produto = _repository.FindByKey(pFilter.ProdutoId);
            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);
                return null;
            }
            
            return produto;

        }

        /// <summary>
        /// Cria um registro na tabela Produto
        /// </summary>
        /// <param name="pModel"></param>
        public Result CreateProduto(Produto pModel, ref Result resultado)
        {
            try
            {
                _repository.Add(pModel);
                _repository.Save();
            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);
            }
       
            return resultado;

        }

        /// <summary>
        /// Altera um registro na tabela Produto
        /// </summary>
        /// <param name="pModel"></param>
        public Result UpdateProduto(Produto pModel, ref Result resultado)
        {
            try
            {
                var produto = _repository.FindByKey(pModel.ProdutoId);

                if (produto != null)
                {
                    Utils.CopyPropertyValues(pModel, produto);

                    _repository.Update(produto);
                    _repository.Save();
                }
            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);
            }

            return resultado;
        }

        /// <summary>
        /// Exclui um registro na tabela Produto
        /// </summary>
        /// <param name="pModel"></param>
        public Result DeleteProduto(Produto pModel, ref Result resultado)
        {
            try
            {
                var produto = _repository.FindByKey(pModel.ProdutoId);

                if (produto != null)
                {
                    _repository.Delete(x=>x.ProdutoId == pModel.ProdutoId);
                    _repository.Save();
                }
            }
            catch (Exception ex)
            {
                resultado.GravarLog(ex);
            }

            return resultado;
        }
    }
}
