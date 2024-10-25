SELECT * FROM db_sistemacadastroclientes.clientes;

create table clientes(
	id_clientes int not null auto_increment primary key,
    nome varchar(255),
    cpf varchar(255)
);

select * from clientes;
