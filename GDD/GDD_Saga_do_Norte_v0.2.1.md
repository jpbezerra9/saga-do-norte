# Game Design Document — *Saga do Norte* (nome provisório)

**Versão:** v0.2 — Direção Visual, Level Design e Expansão Narrativa  
**Data:** 10/09  
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

- **Nome provisório:** Saga do Norte[cite: 1, 2]
- **Gênero:** Estratégia por turnos / Conquista territorial, com viés narrativo[cite: 1, 2]

**Nota de licenciamento:** O professor responsável pela disciplina autorizou o uso direto de personagens, nomes e enredo de *Vinland Saga* (Makoto Yukimura / Wit Studio / MAPPA), visto que o projeto possui fins estritamente acadêmicos e não lucrativos[cite: 1, 2].

---

## 3. High Concept

Em uma terra nórdica fragmentada por clãs em guerra, o jogador acompanha a jornada de Thorfinn — desde a perda de seu pai, Thors, até sua ascensão como guerreiro sob o comando de Askeladd e sua posterior busca por redenção na Fazenda de Ketil — conquistando territórios em batalhas táticas por turno enquanto revive os principais eventos da saga[cite: 1].

---

## 4. Público e Plataforma-Alvo

- **Público:** Jogadores casuais e fãs de estratégia leve, incluindo fãs de *Vinland Saga*[cite: 1, 2]
- **Plataforma:** PC (Windows)[cite: 1, 2]
- **Classificação:** Livre, com violência estilizada (pixel art)[cite: 1, 2]

---

## 5. Objetivo do Jogador

Conduzir Thorfinn (e, no prólogo, Thors) através de batalhas táticas por turno, conquistando territórios ligados à jornada da obra, desde a Islândia e as Ilhas Faroé até o encerramento do arco na Fazenda de Ketil[cite: 1].

---

## 6. Mecânica Principal

Combate tático por turnos em grade (*grid*), com:[cite: 1, 2]
- Posicionamento estratégico de unidades[cite: 1, 2]
- Unidades com atributos, alcances e classes distintas[cite: 1, 2]
- Terreno e obstáculos (destroços, caixas, barris) influenciando o combate e a navegação no mapa[cite: 1, 2]

---

## 7. Mecânicas Secundárias

- **Mapa Estratégico:** Seleção e conquista de territórios com ordem fixa de progressão baseada na cronologia do anime/mangá[cite: 1, 2].
- **Progressão de Personagens:** Unidades ganham experiência, novos atributos e *upgrades* de habilidades[cite: 1, 2].
- **Gestão de Recursos:** Coleta de recursos obtidos ao dominar novos territórios[cite: 1, 2].
- **Cutscenes Narrativas Pós-Batalha:** Eventos-chave da história (derrotas e mortes canônicas) são resolvidos via cutscene narrativa (imagem estática + diálogos), não alterando o resultado mecânico imediato da batalha[cite: 1, 2].

---

## 8. Core Loop
---

## 9. Estrutura de Fases e Progressão de Dificuldade

| Ordem | Fase / Território | Unidade jogável / Foco | Dificuldade | Contexto Narrativo (Referência Anime) |
|---|---|---|---|---|
| **Prólogo** | Ilhas Faroé (Emboscada) | **Thors** | Introdutória / Tutorial | Ep. 4 — Thors enfrenta o bando de Askeladd. O jogador vence a batalha, mas a cutscene exibe a traição e a morte de Thors[cite: 1, 2]. |
| **1** | Ilhas Faroé (Arco Principal) | **Thorfinn** | Fácil | Ep. 14 ("The Light of Dawn") — Duelo de Thorfinn contra Askeladd. Cutscene mostra Thorfinn dominado e recrutado[cite: 1, 2]. |
| **2** | Jomsburg | **Thorfinn** (+ Askeladd) | Média | Contexto de background — Fortaleza dos Jomsvikings, ligada ao passado de Thors[cite: 1, 2]. |
| **3** | Inglaterra (Ponte de Londres) | **Thorfinn** (+ Grupo) | Difícil | Outubro de 1013 — Invasão liderada pelo Rei Sweyn Forkbeard e o bando de Askeladd como mercenários[cite: 1, 2]. |
| **4** | Gales / Fronteira de Wessex | **Thorfinn** / **Askeladd** | Média / Difícil | Ep. 9–12 — Resgate do Príncipe Canute em Gainsborough e escolta tática por Gales[cite: 1]. |
| **5** | Mércia (Acampamento de Inverno) | **Thorfinn** / **Thorkell** | Difícil | Ep. 15–18 — Fuga na neve sob perseguição de Thorkell, motim do bando e duelo mortal[cite: 1]. |
| **6** | York (Jorvik) — O Grande Conselho | **Askeladd** / **Thorfinn** | Muito Difícil (Clímax T1) | Ep. 21–24 — O banquete de Sweyn, a decisão radical de Askeladd para proteger Gales e a perda do objetivo de Thorfinn[cite: 1]. |
| **7** | Fazenda de Ketil (Trabalho e Redenção) | **Thorfinn** (Escravo) / **Einar** | Baixa / Introspectiva | T2 (Ep. 1–9) — Início do Arco do Escravo; foco em mecânicas de sobrevivência, agricultura e trauma pós-guerra[cite: 1]. |
| **8** | Fazenda de Ketil (Confronto de Guardas) | **Thorfinn** / **Snake** | Difícil | T2 (Ep. 14–16) — Ameaça dos mercenários locais e confronto para proteger Arnheid e a paz na fazenda[cite: 1]. |
| **9** | Fazenda de Ketil (Ketil vs Canute) | **Thorfinn** / **Thorkell** (Boss) | Muito Difícil (Clímax T2) | T2 (Ep. 17–22) — Invasão das forças reais. Thorfinn precisa resistir aos golpes de Drott e negociar a paz sem usar armas[cite: 1]. |

**Decisão de Design — Cutscenes de Derrota Narrativa:** Em pontos-chave da história onde os protagonistas são derrotados canonicamente no anime, o jogador realiza a batalha tática normalmente[cite: 1, 2]. Após o cumprimento do objetivo no grid, uma cutscene de imagens estáticas e diálogos contextualiza a reviravolta sem penalizar o progresso do jogador[cite: 1, 2].

---

## 10. Condições de Vitória e Derrota

- **Vitória (Batalha):** Eliminar todas as unidades inimigas ou cumprir o objetivo específico da fase (ex: resistir por X turnos, defender personagem)[cite: 1, 2].
- **Vitória (Geral):** Conquistar todos os 9 territórios/estágios da campanha[cite: 1, 2].
- **Derrota:** Perder todas as unidades jogáveis do grupo na batalha[cite: 1, 2].

---

## 11. Direção de Arte e Personagens

**Estilo Visual:** Pixel Art 16-bit, perspectiva top-down 3/4, proporções estilo *chibi* (2 a 2.5 cabeças de altura), grid compacto (16x32 ou 32x32 px per tile) com contornos escuros e sombreamento direto em blocos (2-3 tons por elemento)[cite: 1, 2].  
**Referências Visuais:** *Stardew Valley*, *Harvest Moon*, RPGs clássicos de SNES/GBA[cite: 1, 2].

### Personagens Principais

#### Thorfinn
- **Papel:** Protagonista jogável principal[cite: 1, 2]
- **Arma:** Adagas[cite: 1, 2]
- **Arquétipo:** Duelista ágil; foco em mobilidade, esquiva e múltiplos ataques diretos[cite: 1, 2].

#### Thors
- **Papel:** Protagonista jogável no Prólogo (Tutorial)[cite: 1, 2]
- **Arma:** Machado de Batalha / Combate Desarmado[cite: 1, 2]
- **Arquétipo:** Guerreiro Pesado / "Troll de Jomsburg"; altíssimo poder ofensivo e defensivo[cite: 1, 2].

#### Askeladd
- **Papel:** Antagonista na Fase 1 / Unidade Estratégica Jogável nas Fases 2, 4 e 6[cite: 1, 2]
- **Arma:** Espada e Machado[cite: 1, 2]
- **Arquétipo:** Comandante Tático; equilibrado entre ataque direto e habilidades de área[cite: 1, 2].

---

## 12. Planejamento de Animações

| Estado | Thorfinn | Thors | Askeladd | Unidades Genéricas (Inimigos/Aliados) |
|---|---|---|---|---|
| **Idle** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Walk** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Attack** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Hit / Hurt** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Death** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Victory** | ✅[cite: 1, 2] | —[cite: 1, 2] | —[cite: 1, 2] | —[cite: 1, 2] |

---

## 13. Concept de Cenários

- **Cenário de Cutscene (Prólogo - Doca/Cais):** Perspectiva cinematográfica em pixel art exibindo o navio viking e os paredões rochosos[cite: 1, 2].
- **Battle Stage (Prólogo - Grid Tático):** Visão top-down com tablado de madeira, barris e caixas utilizáveis como bloqueio de caminho e cobertura tática[cite: 1, 2].
- **Cenários de Campanha:** Campos de neve (Mércia), fortalezas de pedra (Jomsburg/York) e áreas rurais/plantações (Fazenda de Ketil)[cite: 1].

---

## 14. Mapa Estratégico

Mapa territorial interativo estilizado em pixel art estilo "Mapa de Campanha" (inspirado em *Fire Emblem* e *Total War*)[cite: 1, 2].
Exibe os 9 nós estratégicos sequenciais que cobrem a rota cronológica da história[cite: 1].

---

## 15. Referências

- **Obra-base:** *Vinland Saga* (Mangá de Makoto Yukimura; Animes por Wit Studio & MAPPA)[cite: 1, 2]
- **Sistemas de Combate:** *Fire Emblem*, *Into the Breach*[cite: 1, 2]
- **Estratégia Territorial:** *Crusader Kings*, *Total War* (versões simplificadas)[cite: 1, 2]
- **Estilo Artístico:** *Stardew Valley*, RPGs de SNES[cite: 1, 2]

---

## 16. Escopo Atual

- 1 Mapa Estratégico com 9 territórios/estágios[cite: 1]
- Grids de batalha tática 2D com obstáculos manipuláveis por fase[cite: 1, 2]
- Unidades jogáveis: Thorfinn, Thors, Askeladd, além de suporte de unidades no arco de Ketil[cite: 1]
- Foco de produção: Core loop de combate por turnos + interface de seleção de territórios + cenas narrativas[cite: 1, 2].

---

## 17. Repositório e Estrutura do Projeto

- **Repositório:** `github.com/jpbezerra9/saga-do-norte`[cite: 1, 2]
- **Tag da Entrega:** `v0.2`[cite: 1, 2]
- **Estrutura de Pastas:** `/GDD`, `/UnityProject`, `/Art`, `/Animation`, `/Audio`, `/LevelDesign`, `/QA`[cite: 1, 2]

---

## 9. Estrutura de Fases e Progressão de Dificuldade

| Ordem | Fase / Território | Unidade jogável / Foco | Dificuldade | Contexto Narrativo (Referência Anime) |
|---|---|---|---|---|
| **Prólogo** | Ilhas Faroé (Emboscada) | **Thors** | Introdutória / Tutorial | Ep. 4 — Thors enfrenta o bando de Askeladd. O jogador vence a batalha, mas a cutscene exibe a traição e a morte de Thors[cite: 1, 2]. |
| **1** | Ilhas Faroé (Arco Principal) | **Thorfinn** | Fácil | Ep. 14 ("The Light of Dawn") — Duelo de Thorfinn contra Askeladd. Cutscene mostra Thorfinn dominado e recrutado[cite: 1, 2]. |
| **2** | Jomsburg | **Thorfinn** (+ Askeladd) | Média | Contexto de background — Fortaleza dos Jomsvikings, ligada ao passado de Thors[cite: 1, 2]. |
| **3** | Inglaterra (Ponte de Londres) | **Thorfinn** (+ Grupo) | Difícil | Outubro de 1013 — Invasão liderada pelo Rei Sweyn Forkbeard e o bando de Askeladd como mercenários[cite: 1, 2]. |
| **4** | Gales / Fronteira de Wessex | **Thorfinn** / **Askeladd** | Média / Difícil | Ep. 9–12 — Resgate do Príncipe Canute em Gainsborough e escolta tática por Gales[cite: 1]. |
| **5** | Mércia (Acampamento de Inverno) | **Thorfinn** / **Thorkell** | Difícil | Ep. 15–18 — Fuga na neve sob perseguição de Thorkell, motim do bando e duelo mortal[cite: 1]. |
| **6** | York (Jorvik) — O Grande Conselho | **Askeladd** / **Thorfinn** | Muito Difícil (Clímax T1) | Ep. 21–24 — O banquete de Sweyn, a decisão radical de Askeladd para proteger Gales e a perda do objetivo de Thorfinn[cite: 1]. |
| **7** | Fazenda de Ketil (Trabalho e Redenção) | **Thorfinn** (Escravo) / **Einar** | Baixa / Introspectiva | T2 (Ep. 1–9) — Início do Arco do Escravo; foco em mecânicas de sobrevivência, agricultura e trauma pós-guerra[cite: 1]. |
| **8** | Fazenda de Ketil (Confronto de Guardas) | **Thorfinn** / **Snake** | Difícil | T2 (Ep. 14–16) — Ameaça dos mercenários locais e confronto para proteger Arnheid e a paz na fazenda[cite: 1]. |
| **9** | Fazenda de Ketil (Ketil vs Canute) | **Thorfinn** / **Thorkell** (Boss) | Muito Difícil (Clímax T2) | T2 (Ep. 17–22) — Invasão das forças reais. Thorfinn precisa resistir aos golpes de Drott e negociar a paz sem usar armas[cite: 1]. |

**Decisão de Design — Cutscenes de Derrota Narrativa:** Em pontos-chave da história onde os protagonistas são derrotados canonicamente no anime, o jogador realiza a batalha tática normalmente[cite: 1, 2]. Após o cumprimento do objetivo no grid, uma cutscene de imagens estáticas e diálogos contextualiza a reviravolta sem penalizar o progresso do jogador[cite: 1, 2].

---

## 10. Condições de Vitória e Derrota

- **Vitória (Batalha):** Eliminar todas as unidades inimigas ou cumprir o objetivo específico da fase (ex: resistir por X turnos, defender personagem)[cite: 1, 2].
- **Vitória (Geral):** Conquistar todos os 9 territórios/estágios da campanha[cite: 1, 2].
- **Derrota:** Perder todas as unidades jogáveis do grupo na batalha[cite: 1, 2].

---

## 11. Direção de Arte e Personagens

**Estilo Visual:** Pixel Art 16-bit, perspectiva top-down 3/4, proporções estilo *chibi* (2 a 2.5 cabeças de altura), grid compacto (16x32 ou 32x32 px per tile) com contornos escuros e sombreamento direto em blocos (2-3 tons por elemento)[cite: 1, 2].  
**Referências Visuais:** *Stardew Valley*, *Harvest Moon*, RPGs clássicos de SNES/GBA[cite: 1, 2].

### Personagens Principais

#### Thorfinn
- **Papel:** Protagonista jogável principal[cite: 1, 2]
- **Arma:** Adagas[cite: 1, 2]
- **Arquétipo:** Duelista ágil; foco em mobilidade, esquiva e múltiplos ataques diretos[cite: 1, 2].

#### Thors
- **Papel:** Protagonista jogável no Prólogo (Tutorial)[cite: 1, 2]
- **Arma:** Machado de Batalha / Combate Desarmado[cite: 1, 2]
- **Arquétipo:** Guerreiro Pesado / "Troll de Jomsburg"; altíssimo poder ofensivo e defensivo[cite: 1, 2].

#### Askeladd
- **Papel:** Antagonista na Fase 1 / Unidade Estratégica Jogável nas Fases 2, 4 e 6[cite: 1, 2]
- **Arma:** Espada e Machado[cite: 1, 2]
- **Arquétipo:** Comandante Tático; equilibrado entre ataque direto e habilidades de área[cite: 1, 2].

---

## 12. Planejamento de Animações

| Estado | Thorfinn | Thors | Askeladd | Unidades Genéricas (Inimigos/Aliados) |
|---|---|---|---|---|
| **Idle** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Walk** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Attack** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Hit / Hurt** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Death** | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] | ✅[cite: 1, 2] |
| **Victory** | ✅[cite: 1, 2] | —[cite: 1, 2] | —[cite: 1, 2] | —[cite: 1, 2] |

---

## 13. Concept de Cenários

- **Cenário de Cutscene (Prólogo - Doca/Cais):** Perspectiva cinematográfica em pixel art exibindo o navio viking e os paredões rochosos[cite: 1, 2].
- **Battle Stage (Prólogo - Grid Tático):** Visão top-down com tablado de madeira, barris e caixas utilizáveis como bloqueio de caminho e cobertura tática[cite: 1, 2].
- **Cenários de Campanha:** Campos de neve (Mércia), fortalezas de pedra (Jomsburg/York) e áreas rurais/plantações (Fazenda de Ketil)[cite: 1].

---

## 14. Mapa Estratégico

Mapa territorial interativo estilizado em pixel art estilo "Mapa de Campanha" (inspirado em *Fire Emblem* e *Total War*)[cite: 1, 2].
Exibe os 9 nós estratégicos sequenciais que cobrem a rota cronológica da história[cite: 1].

---

## 15. Referências

- **Obra-base:** *Vinland Saga* (Mangá de Makoto Yukimura; Animes por Wit Studio & MAPPA)[cite: 1, 2]
- **Sistemas de Combate:** *Fire Emblem*, *Into the Breach*[cite: 1, 2]
- **Estratégia Territorial:** *Crusader Kings*, *Total War* (versões simplificadas)[cite: 1, 2]
- **Estilo Artístico:** *Stardew Valley*, RPGs de SNES[cite: 1, 2]

---

## 16. Escopo Atual

- 1 Mapa Estratégico com 9 territórios/estágios[cite: 1]
- Grids de batalha tática 2D com obstáculos manipuláveis por fase[cite: 1, 2]
- Unidades jogáveis: Thorfinn, Thors, Askeladd, além de suporte de unidades no arco de Ketil[cite: 1]
- Foco de produção: Core loop de combate por turnos + interface de seleção de territórios + cenas narrativas[cite: 1, 2].

---

## 17. Repositório e Estrutura do Projeto

- **Repositório:** `github.com/jpbezerra9/saga-do-norte`[cite: 1, 2]
- **Tag da Entrega:** `v0.2`[cite: 1, 2]
- **Estrutura de Pastas:** `/GDD`, `/UnityProject`, `/Art`, `/Animation`, `/Audio`, `/LevelDesign`, `/QA`[cite: 1, 2]