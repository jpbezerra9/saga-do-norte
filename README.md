# ⚔️ Saga do Norte

> **Jogo de Estratégia Tática por Turnos & Conquista Territorial em Pixel Art 2D**  
> *Projeto desenvolvido em C# na engine Unity para a disciplina de **Projeto de Jogos Digitais I**.*

---

## 📌 Sobre o Projeto

**Saga do Norte** é um jogo tático por turnos que adapta a saga de Thorfinn (inspirado em *Vinland Saga*). O jogador comanda unidades em embates táticos em grade (*grid*), conquista territórios em um mapa estratégico e acompanha a evolução narrativa do protagonista — desde a perda de seu pai nas Ilhas Faroé até a busca por redenção na Fazenda de Ketil.

> ⚖️ **Nota Acadêmica:** Projeto sem fins lucrativos. O uso de nomes, enredo e personagens adaptados de *Vinland Saga* possui autorização estritamente acadêmica do professor da disciplina.

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
| 10/09 | `v0.2` | Direção Visual e Level Design *(Atual)* |
| 17/09 | `v0.3` | Protótipo Jogável |
| 24/09 | `v0.4` | Vertical Slice |
| 01/10 | `v0.5` | Beta / Feature Lock |
| 08/10 | `v1.0` | Versão Final |

---

## 📊 Status Atual — Entrega 2 (`v0.2`)

* **Artes & Sprites:** Concept arts em Pixel Art 16-bit finalizados para Thorfinn, Thors e Askeladd (`Art/ConceptArt/`).
* **Level Design:** Visual e tablado de combate do Prólogo concluídos (`LevelDesign/`).
* **Mapa de Campanha:** Arte do mapa estratégico atualizada cobrindo os 9 territórios (`LevelDesign/mapa_estrategico_v2.png`).
* **GDD & Documentação:** Atualizado com mecânicas de combate, cutscenes pós-batalha e detalhamento das fases (`GDD/GDD_Saga_do_Norte_v0.2.md`).

---

## 📁 Estrutura do Repositório

```text
saga-do-norte/
├── GDD/             # Documentação de design (GDD_Saga_do_Norte_v0.2.md)
├── UnityProject/    # Código C# e projeto Unity
├── Art/
│   ├── ConceptArt/  # Concept arts dos personagens
│   ├── ModelSheets/ # Proporções e referências visuais
│   ├── Sprites/     # Spritesheets de gameplay
│   └── UI/          # Elementos de interface e HUD
├── Animation/       # Animation Controllers e Clipes 2D
├── Audio/
│   ├── SFX/         # Efeitos sonoros
│   └── Music/       # Trilha sonora
├── LevelDesign/     # Grids de combate e Mapa Estratégico
└── QA/              # Registros de playtesting e bugs
