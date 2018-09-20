-- Cria o extensão do UUID
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

DO $$
	BEGIN
		CREATE TABLE "PessoaFisica" (
			"Id" serial PRIMARY KEY,
			"Cpf" VARCHAR(20),
			"DataNascimento" TIMESTAMP,
			"Ativo" BOOLEAN DEFAULT TRUE,
			"Criado" TIMESTAMP DEFAULT NOW()
		)
		CREATE INDEX "PessoaFisica_Id_UIdx" ON "PessoaFisica" USING BTREE ("Id");
	END;
$$;

DO $$
	BEGIN
		CREATE TABLE "PessoaJuridica" (
			"Id" serial PRIMARY KEY,
			"Cnpj" VARCHAR(20),
			"RazaoSocial" VARCHAR(50),
			"Ativo" BOOLEAN DEFAULT TRUE,
			"Criado" TIMESTAMP DEFAULT NOW()
		)
		CREATE INDEX "PessoaJuridica_Id_UIdx" ON "PessoaJuridica" USING BTREE ("Id");
	END;
$$;

DO $$
	BEGIN
		CREATE TABLE "Cliente" (
			"Id" serial PRIMARY KEY,
			"Uuid" uuid NOT NULL DEFAULT uuid_generate_v4(),
			"Nome" VARCHAR(100),
			"PessoaFisicaId" INTEGER,
			"PessoaJuridicaId" INTEGER,
			"Ativo" BOOLEAN DEFAULT TRUE,
			"Criado" TIMESTAMP DEFAULT NOW(),
			CONSTRAINT "Cliente_PessoaFisica_Fk_Id" FOREIGN KEY ("PessoaFisicaId") REFERENCES "PessoaFisica"("Id"),
			CONSTRAINT "Cliente_PessoaJuridica_Fk_Id" FOREIGN KEY ("PessoaJuridicaId") REFERENCES "PessoaJuridica"("Id")
		)
		CREATE INDEX "Cliente_Uuid_UIdx" ON "Cliente" USING BTREE ("Uuid");
		CREATE INDEX "Cliente_Id_UIdx" ON "Cliente" USING BTREE ("Id");
		CREATE INDEX "Cliente_PessoaFisica_UIdx" ON "Cliente" USING BTREE ("PessoaFisicaId");
		CREATE INDEX "Cliente_PessoaJuridica_UIdx" ON "Cliente" USING BTREE ("PessoaJuridicaId");
	END;
$$;