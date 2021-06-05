create Database CrudProdutoDB

Use CrudProdutoDB

CREATE TABLE Produto (
  ProdutoId BIGINT NOT NULL identity,
  Nome VARCHAR(144) NOT NULL,
  ValorVenda NUMERIC(18,2) NOT NULL,
  PathImagem VARCHAR(255) NULL,
  PRIMARY KEY(ProdutoId)
);

