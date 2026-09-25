# ⚔️ Saga do Norte

> **Jogo de Estratégia Tática por Turnos & Conquista Territorial em Pixel Art 2D**  
> *Projeto desenvolvido em C# na engine Unity para a disciplina de **Projeto de Jogos Digitais **.*

---

## 📌 Sobre o Projeto

**Saga do Norte** é um jogo tático por turnos que adapta a saga de Thorfinn (inspirado em *Vinland Saga*). O jogador comanda unidades em embates táticos em grade (*grid*), conquista territórios em um mapa estratégico e acompanha a evolução narrativa do protagonista — desde a perda de seu pai nas Ilhas Faroé até a busca por redenção na Fazenda de Ketil.

> ⚖️ **Nota Acadêmica:** Projeto sem fins lucrativos. O uso de nomes, enredo e personagens adaptados de *Vinland Saga* possui autorização estritamente acadêmica.

---

## ⚙️ Mecânicas Principais

* **Combate Tático de RPG:** Gerenciamento de Vida (HP) e Estamina através de um Menu de Ações em turnos (Ataque Leve, Ataque Pesado, Defesa e Esquiva).
* **Rolagens e Atributos:** O combate utiliza os atributos base dos personagens (Força e Agilidade) para calcular ocultamente chances de Acerto Crítico, Contra-Ataque e Sucesso de Esquiva.
* **Mapa de Conquista:** Navegação macro entre batalhas através de um mapa estratégico estilo *Total War*.
* **Feedback Visual:** Textos flutuantes informam resultados imediatos no cenário ("Crítico!", "Defendido!", "Esquivou!", Valores de Dano).

---

## 👥 Equipe & Papéis

| Integrante | Função |
|---|---|
| **João Pedro Bezerra Silva** | Artista 2D, Animador, Game Designer & Producer |
| **Adan Crystian** | Programador & Sound Designer |
| **Bryan Rongelli** | Level Designer |
| **Tatiane Oliveira** | QA (Quality Assurance) |

---

## 🗺️ Progressão da Campanha (Fases)

| # | Fase / Território | Unidade Principal | Dificuldade | Arco Narrativo |
|:---:|---|---|:---:|---|
| **0** | Ilhas Faroé (Prólogo) | Thors | Tutorial | Emboscada de Askeladd a Thors |
| **1** | Ilhas Faroé (Arco Principal) | Thorfinn | Fácil | Primeiro duelo contra Askeladd |
| **2** | Jomsburg | Thorfinn / Askeladd | Média | Fortaleza dos Jomsvikings |
| **3** | Inglaterra (Ponte de Londres) | Thorfinn | Difícil | Invasão com o exército dinamarquês |
| **4** | Gales / Fronteira de Wessex | Thorfinn / Askeladd | Média / Difícil | Escolta do Príncipe Canute |
| **5** | Mércia (Acampamento) | Thorfinn / Thorkell | Difícil | Perseguição na neve e duelo |
| **6** | York (Jorvik) | Askeladd / Thorfinn | Muito Difícil | Clímax da 1ª Temporada |
| **7** | Fazenda de Ketil (Redenção) | Thorfinn / Einar | Introspectiva | Início do Arco do Escravo |
| **8** | Fazenda de Ketil (Guardas) | Thorfinn / Snake | Difícil | Confronto com os mercenários |
| **9** | Fazenda de Ketil (Invasão) | Thorfinn / Thorkell | Muito Difícil | Clímax da 2ª Temporada |

---

## 📅 Cronograma de Entregas

| Data | Versão | Etapa |
|:---:|:---:|---|
| 03/09 | `v0.1` | Concepção e GDD Inicial |
| 10/09 | `v0.2` | Direção Visual e Level Design |
| 17/09 | `v0.3` | Protótipo Jogável |
| 24/09 | `v0.4` | Vertical Slice *(Atual)* |
| 01/10 | `v0.5` | Beta / Feature Lock |
| 08/10 | `v1.0` | Versão Final |

---

## 📊 Status Atual — Entrega 4 (`v0.4` - Vertical Slice)

* **Gameplay Integrado:** *Core loop* funcional com transição fluida entre o Mapa Estratégico e a Batalha do Prólogo (`SceneManager`).
* **Sistema de Combate:** Lógica matemática de atributos totalmente implementada (consumo de estamina, cálculos de dano base e crítico, mecânicas de defesa e esquiva com contra-ataque).
* **Interface e Feedback:** HUD completo com barras dinâmicas, painel de ações bloqueável durante turnos inimigos e instanciamento de *Damage Numbers* no ambiente de combate.
* **Integração de Assets:** Sprites em Pixel Art aplicados aos personagens e cenários no Unity, em conformidade com as delimitações de *Level Design*. Implementação base de áudio estruturada.
* **Narrativa:** Sistema de "Falso Final Feliz" integrado via *Video Player* ativado em condições específicas de vitória alternativa.
* **GDD & Documentação:** Atualizado para refletir o escopo real e ajustes da sprint (`GDD/GDD_Saga_do_Norte_v0.4.md`).

---

## 📁 Estrutura do Repositório

```text
saga-do-norte/
├── GDD/             # Documentação de design viva (GDD_Saga_do_Norte_vX.X)
├── UnityProject/    # Código C# e projeto Unity
├── Art/
│   ├── ConceptArt/  # Concept arts dos personagens
│   ├── ModelSheets/ # Proporções e referências visuais
│   ├── Sprites/     # Spritesheets de gameplay integrados
│   └── UI/          # Elementos de interface e HUD
├── Animation/       # (Backlog) Animation Controllers e Clipes 2D
├── Audio/
│   ├── SFX/         # Efeitos sonoros
│   └── Music/       # Trilha sonora
├── LevelDesign/     # Grids de combate e Mapa Estratégico
└── QA/              # Registros de playtesting e bugs