# App Clínica

## APIs
- Login (parâmetro de quem está acessando - retorna a estrutura do usuário)
- Cadastro de paciente
- Cadastro de aluno
- Cadastro de professor
- Cadastro de funcionário
- Responder consulta (confirmar ou cancelar - mobile)
- Ver consultas do mês (query por filtros - especialidade, professor, aluno, paciente, status, data)
- Ver detalhe de consulta (busca pelo id)
- Ver notificações (query por filtros)
- Solitar paciente (2 variações de requisição)

## APIs adicionais:
- Reset de senha (parâmetro de quem está acessando)
- Cadastro de consulta

## Regras de negócio
### Paciente
- O paciente só pode cancelar a consulta até 48 horas uteis antes do atendimento.
- O paciente deve confirmar a consulta até 48 horas antes do atendimento.
- O paciente que faltar na consulta deverá ser punido e colocado fim da fila
- O paciente deve ter como consultar onde vai ser atendido e a que horas será atendido.
- Caso o paciente não confirme a consulta o mesmo perderá o direito e voltará para a fila de espera
### Recepcionista
- A recepcionista deve cadastrar os pacientes no sistema.
- A recepcionista deve marcar qual o tipo de tratamento / qual especialidade o paciente precisa.
- A recepcionista deve ter acesso as informações do aluno, paciente e professor
### Aluno
- O aluno tem que solicitar um novo paciente pelo formulário com pelo menos 48 horas uteis de antecedência do dia da aula.
- O aluno só pode cancelar a consulta até 48 horas uteis antes do atendimento.
- O aluno deve registrar o retorno do paciente até 48 horas uteis depois da consulta.
- O aluno deve poder ver informações sobre o problema do paciente.
- O aluno deve estar vinculado a um professor.
- O aluno deve poder consultar a que horas vai ser o atendimento e o respectivo local
### Professor
- O professor deve registrar o retorno do paciente até 48 horas uteis depois da consulta.
- O professor pode definir qual a especialidade da aula.
- O professor deve poder enviar dados para o prontmed.
- O professor deve poder montar a agenda de aulas.
- O professor deve ter como avaliar os alunos e manter um registro dos mesmos.
- O professor deve poder consultar a que horas vai ser o atendimento e o respectivo local
### Responsável técnico
- O responsável técnico deve fazer o acompanhamento do sistema, deve ter acesso as informações de todos, porém não pode alterar nada. O aluno deve poder consultar a que horas vai ser o atendimento e o respectivo local

