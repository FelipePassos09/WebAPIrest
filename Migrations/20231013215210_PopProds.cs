using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopProds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImmage,Estoque,DataCadastro,CategoriaId)" +
                "Values('Coca-Cola','Refrigerenate de Cola 350ml',5.45,'cocacola.jpg',50,now(),1)");
            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImmage,Estoque,DataCadastro,CategoriaId)" +
                "Values('Sanduiche de Presunto','Sanduiche frio de presunto e queijo.',6.25,'sndpresunto.jpg',50,now(),2)");
            migrationBuilder.Sql("Insert into Produtos(Nome,Descricao,Preco,UrlImmage,Estoque,DataCadastro,CategoriaId)" +
                "Values('Pudim de Leite','Pudim tradicional de leite condensado.',8.50,'pdmleite.jpg',50,now(),3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Produtos");
        }
    }
}
