# EduTechPlatform - Qualidade e Testes de Software com xUnit

## 📌 Visão Geral
O **EduTechPlatform** é uma solução em .NET desenvolvida para centralizar e validar regras de negócio essenciais de uma plataforma educacional, abrangendo três domínios principais: **desempenho académico**, **controlo de frequência** e **gestão financeira de matrículas**.

A solução está estruturada em dois projetos:
* **`EduTechPlatform.App`**: Aplicação principal contendo as classes de serviço e regras de negócio do domínio académico e financeiro.
* **`EduTechPlatform.Tests`**: Projeto de testes unitários automatizados construído com **xUnit** para assegurar a qualidade e a cobertura integral das regras do sistema.

---

## ⚙️ Requisitos do Ambiente de Execução
Para clonar, compilar e executar este projeto localmente, é necessário ter instalado:
* **[.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)** (`net10.0`)
* **Git** (para controlo de versões)
* Editor de código ou IDE (como **Visual Studio Code** ou **Visual Studio**)

Para verificar se o SDK do .NET 10 está instalado corretamente, execute no terminal:
```bash
dotnet --version
```

---

## 🧩 Arquitetura e Classes de Serviço (`EduTechPlatform.App`)

### 1. `NotaDesempenhoService`
Responsável pelo cálculo do rendimento escolar e definição da situação académica do aluno:
* **`CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)`**: Calcula a média final aplicando peso **3** para a Nota 1, peso **3** para a Nota 2 e peso **4** para a Nota de Projeto, segundo a fórmula `((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10`.
* **`ObterSituacaoAcademica(decimal mediaFinal)`**: Classifica a situação do estudante com base na média final obtida:
  * `mediaFinal >= 7.0m`: Retorna `"APROVADO"`
  * `mediaFinal` entre `5.0m` e `6.99m`: Retorna `"RECUPERACAO"`
  * `mediaFinal < 5.0m`: Retorna `"REPROVADO"`

### 2. `FrequenciaService`
Responsável pelo acompanhamento de assiduidade e validação do critério mínimo de presença:
* **`CalcularPorcentagemPresenca(int aulasTotais, int faltas)`**: Calcula e retorna o percentual de presença do aluno através da fórmula `((aulasTotais - faltas) / (double)aulasTotais) * 100`.
* **`AprovadoPorFrequencia(int aulasTotais, int faltas)`**: Avalia se o estudante atingiu a frequência mínima exigida de **75%**, retornando `true` caso seja aprovado e `false` caso contrário.

### 3. `MatriculaFinanceiraService`
Responsável pela aplicação de políticas de desconto nas mensalidades e validação de elegibilidade para renovação de matrícula:
* **`CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)`**:
  * **Alunos bolseiros (`eBolsista == true`)**: Desconto fixo de **50%** (`valorBase * 0.50m`), independentemente do dia de pagamento.
  * **Não bolseiros com pagamento até ao dia 5**: Desconto de pontualidade de **10%** (`valorBase * 0.90m`).
  * **Não bolseiros com pagamento após o dia 5**: Valor integral (`valorBase`).
* **`PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)`**: Retorna `true` apenas se `possuiPendenciaFinanceira == false` **e** a `situacaoAcademica` **não** for `"REPROVADO"`.

---

## 🚀 Guia de Execução (.NET CLI)

Abra o terminal na pasta raiz da solução (`EduTechPlatform`) e execute os comandos abaixo por ordem:

### 1. Restaurar as dependências dos projetos
```bash
dotnet restore
```

### 2. Compilar a solução
```bash
dotnet build
```

### 3. Executar a suíte de testes automatizados
```bash
dotnet test
```

---

## 🧪 Cobertura de Testes Parametrizados (`xUnit`)

O projeto `EduTechPlatform.Tests` utiliza testes orientados a dados (*Data-Driven Tests*) através das anotações **`[Theory]`** e **`[InlineData]`** do framework **xUnit**.

Enquanto um teste tradicional com `[Fact]` valida apenas um cenário fixo, o atributo **`[Theory]`** torna o método de teste numa especificação parametrizada. Cada atributo **`[InlineData(...)]`** injeta um conjunto diferente de valores de entrada e o respetivo resultado esperado diretamente nos parâmetros do método, garantindo cobertura total das regras de negócio sem repetição de código:

* **`NotaDesempenhoServiceTests`**: Valida o cálculo de médias ponderadas (`7.0` e `8.0`) e testa todas as faixas de decisão da situação académica (`"APROVADO"`, `"RECUPERACAO"` e `"REPROVADO"`).
* **`FrequenciaServiceTests`**: Valida o cálculo exato do percentual de presença (`75.0%` e `90.0%`) e testa os valores limite de aprovação por frequência (`true` com `20` faltas em `80` aulas; `false` com `21` faltas em `80` aulas).
* **`MatriculaFinanceiraServiceTests`**: Verifica todas as regras de desconto na mensalidade (`50%` para bolseiro, `10%` até ao dia 5 e valor integral após o dia 5) e valida os cenários de permissão ou bloqueio de rematrícula consoante pendências financeiras e situação académica.

xd
---

## 📄 Licença
Este projeto está licenciado sob a **MIT License**. Consulte o ficheiro [LICENSE](LICENSE) para mais informações.
