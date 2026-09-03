# Game Design Document — *Saga do Norte* (nome provisório)

**Versão:** v0.1 — Concepção e GDD Inicial
**Data:** 03/09
**Disciplina:** Projeto de Jogos Digitais I — Desenvolvimento de um Jogo 2D com Unity

---

## 1. Equipe e Papéis

| Nome | Papel |
|---|---|
| João Pedro Bezerra Silva | Artista 2D + Animador / Game Designer + Producer |
| Adan Crystian | Programador + Sound Designer |
| Bryan Rongelli | Level Designer |
| Tatiane Oliveira | QA |

---

## 2. Nome Provisório e Gênero

**Nome provisório:** Saga do Norte
**Gênero:** Estratégia por turnos / Conquista territorial, com viés narrativo

---

## 3. High Concept

Em uma terra nórdica fragmentada por clãs em guerra, o jogador assume o comando de um pequeno grupo de guerreiros e deve conquistar, ilha por ilha, o controle da região — equilibrando combates táticos por turno com decisões de gestão territorial (recursos, alianças, expansão).

---

## 4. Público e Plataforma-Alvo

- **Público:** Jogadores casuais e fãs de estratégia leve
- **Plataforma:** PC (Windows)
- **Classificação:** Livre, com violência estilizada (pixel art)

---

## 5. Objetivo do Jogador

Expandir o domínio do clã conquistando territórios adjacentes no mapa estratégico, derrotando os clãs rivais em batalhas táticas por turno.

---

## 6. Mecânica Principal

Combate tático por turnos em grade (grid), com:
- Posicionamento de unidades
- Unidades com atributos e classes distintas
- Influência do terreno no combate

---

## 7. Mecânicas Secundárias Previstas

- Mapa estratégico de conquista de territórios (estilo mapa-múndi com ilhas/regiões clicáveis)
- Progressão do clã (unidades ganham experiência e upgrades)
- Recursos simples obtidos por território conquistado

---

## 8. Core Loop

1. Selecionar território alvo no mapa estratégico
2. Batalha tática por turnos
3. Vitória → conquista do território (e seus recursos)
4. Uso dos recursos para fortalecer o clã
5. Repetir até dominar o mapa

---

## 9. Condições de Vitória e Derrota

- **Vitória:** Conquistar todos os territórios do mapa (ou uma porcentagem definida)
- **Derrota:** Perder todas as unidades do clã, ou o território-base ser conquistado pelo inimigo

---

## 10. Referências

- **Tom e ambientação:** inspirado no universo viking (não baseado em obra licenciada específica — nomes, personagens e enredo são originais)
- **Combate tático:** Fire Emblem, Into the Breach
- **Conquista territorial:** Crusader Kings, Total War (versão simplificada)

---

## 11. Escopo Inicial

- 1 mapa estratégico com 3 a 5 territórios
- 1 tipo de batalha tática (grid simples)
- 2 a 3 tipos de unidade
- Sem sistema de diplomacia complexo nesta fase
- Foco em ter o core loop jogável e polido antes de expandir conteúdo

---

## 12. Repositório do Projeto

- Repositório único a ser mantido durante todo o desenvolvimento
- Tag desta entrega: **v0.1**
- Estrutura sugerida de pastas:
  - `/GDD` — este documento e versões futuras
  - `/UnityProject` — projeto Unity e código C#
  - `/Art` — concept arts, model sheets, sprites, cenários
  - `/Animation` — animações
  - `/Audio` — efeitos sonoros e trilha
  - `/LevelDesign` — mapas e planejamento de fases
  - `/QA` — registros de playtesting e bugs

---

*Documento vivo — será atualizado a cada entrega conforme o desenvolvimento avança.*
