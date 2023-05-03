# Mario Remastered

Mario Remastered trata-se de um pequeno remake que inclui apenas 1 nível no total e o movimento do jogador.

## Trabalho realizado por:

- [Francisco Oliveira](https://github.com/Sincops) - 25979
- [Tomás Carvalho](https://github.com/GR3ENP1G08) - 25963
- [João Rego](https://github.com/Sewerat29) - 26533

# Funcionalidades

- O personagem é controlado pelas setas do teclado

- Se pressionar X no teclado muda o estado do personagem, troca entre mario pequeno, grande e mario de fogo.

- O esc no teclado fecha o jogo.

- Os inimigos movem se da direita para esquerda e vice-versa ate baterem contra uma superficie.

- Para matar os inimigos do jogo basta cair em cima deles.

- Por enquanto não tem gameover ou morte do personagem então quando se leva dano e esta grande vira se pequeno e em pequeno os inimigos batem contra o personagem mas ele não morre.

- Tem musica de fundo e efeito sonoros.

---

## Organização das Pastas e Ficheiros

#### Pasta Inicial - "marioremastered"

- Esta pasta inicial contêm as seguintes subpastas e ficheiros:
  - .git;
  - MarioRemastered;
  - source;
  - .gitattributes;
  - image;
  - README.

##### . git

- Esta pasta permanece escondida a não ser que o utilizador revele hidden items, através de View > Show > Hidden Items.
- Contêm todos os ficheiros necessários para manipular o repositório do git.

##### MarioRemastered

- Onde está situado o ficheiro .exe (executable) do jogo, denominado por MarioRemastered.
- Vários ficheiros .dll e .xml:
  - **. dll (Dynamic Link Library):** tipo de ficheiro que contêm código e dados que podem ser usados por váriso programas, de maneira a poupar memória;
  - **. xml (Extensible Markup Language):** usado para armazenamento de dados, ficheiros de configuração e serviços web.
- Um Manifest file e um .pdb:
  - **. Manifest:** contêm informação sobre os ficheiros que compõem uma determindada aplicação;
  - **. pbd (Program Database):** gerado por um compiler ou linker. Contêm informação que ajuda developers com o debug do código.
- **Content:**  onde estão guardados os ficheiros .xnb:
  - **. xnb (XNA Game Studio binary file):** usado para guardar e dar load a conteúdo como graficos, ficheiros de som e outros ficheiros que compõem um jogo. 

##### source

- **MarioRemastered:**
  - Contêm o source code correspondentes ao projeto.
  - **bin (binary):** contêm o codigo compilado do projeto que o programa consegue executar. Também, incluí uma série de .dll, .xml.
  - **Content:** assets do jogo, como sprites, musica, etc. Incluí 2 pastas, bin e obj.
    - **bin:** vários ficheiros .xnb.
    - **obj:** ficheiros alusivos ao Monogame como .mgcontent e .mgstats. 
  - **obj:** incluí pastas x86 > Debug.
    - .exe;
    - c# sources files;
    - cache;
      - **cache:** dados temporários que permitem acesso rápido a dados e ficheiros usados frequentemente.
    - pdb
    - resources
    - Text documenta
  - **Properties:** contêm AssemblyInfo.cs.
  - **AssemblyInfo.cs:** metadata sobre um programa, incluindo a sua versão, copyright e outros dados associados.
  - Vários ficheiros .cs, um ICO, Manifest e .rexs.
    - **ICO (Icon):** tipo de ficheiro usado para indicadores visuais para ficheiros, pastas, etc.
    - **resx (resource XML):** um tipo de ficheiro XL que usa a framework .NET.
- **vs:** pasta escondida, criada pelo ide (integrated development environment) Visual Studio que contêm informação sobre a configuração e estado de um projeto. Informação como definições do ide e debug.
- **sln (solution):** contêm informação sobre a estrutura do projeto, dependências e configurações da build. Também é usado para manter informação sobre a versão do projeto.

##### .gitattributes

- usado pelo git para determinar instruções e atributos para ficheiros e pastas.

##### image.jpg

- Curta descrição do projeto em formato .jpg.

##### README

- ficheiro de texto com informação sobre os controlos do jogo, criador, demo, bugs, créditos aos autores da música, etc.

---

### Game1

> ##### Variáveis
> 
> ```cs
> public class Game1 : Game {   
>     GraphicsDeviceManager graphics;
>     Song song;
>     SoundEffect hop;
>     KeyboardState ks1, ks2;
>     public static SpriteBatch spriteBatch;
>     Player mario;
>     Ground ground,ground2,ground3,kutular1,boru1,boru2,boru4,boru5,kutular2,kutular3,boru3,
>             kutular4,kutular5,kutular6,kutular7,kutular8, miniboru1;
>     Coin coin1, coin2, coin3, coin4, coin5,coin6, coin7, coin8, coin9,coin10, coin11, coin12, coin13, coin14;
>     Monster mon1,mon2;
>     MushroomGround mantarkutu1,mantarkutu2;
>     CoinGround coinkutu1,coinkutu2,coinkutu3,coinkutu4,coinkutu5;
>     List<Ground> currentGroundList;
>     List<MushroomGround> currentMushroomGroundList;
>     List<Mushroom> currentMushroomList;
>     List<Coin> currentCoinList;
>     List<CoinGround> currentCoinGroundList;
>     List<Monster> currentMonsterList;
>     Texture2D background;
>     Vector2 bgposition = new Vector2(0, 0);
>     TimeSpan x = new TimeSpan(0, 0, 0);
> ```
> 
> Aqui são criadas as variáveis principais para jogo, isto inclui:
> 
> - "driver" do som - para poder dar play a qualquer som do jogo utilizando os methodos existentes nesse objeto.
> 
> - Todos os elementos que aparecem no jogo: Jogador, Coletáveis, Enimigos - Todos estes numa lista.

> ##### Initialize
> 
> ```cs
> protected override void Initialize() {
>   mario = new Player(Content);
>   ground = new Ground(Content, mario,"aa",0,600);
>   ground2 = new Ground(Content, mario, "aa", 1280, 600);
>   ground3 = new Ground(Content, mario, "aa", 2560, 600);
>   kutular1 = new Ground(Content, mario, "kutular", 500, 440);
> //...
>   currentGroundList = new List<Ground>();
>   currentGroundList.Add(ground);
>   currentGroundList.Add(ground2);
>   currentGroundList.Add(ground3);
>   currentGroundList.Add(kutular1);
>   currentGroundList.Add(kutular2);
> //...
>   base.Initialize();
> }
> ```
> 
> Inicialização dos elementos do jogo
> 
> - Neste método é realizado a inicialização das variáveis do jogo para depois serem carregadas para o nível.
> 
> - Cada tipo de elemento é colocado numa lista (ex: moedas, chão...).

> ##### LoadContent
> 
> ```cs
> protected override void LoadContent() {
>     spriteBatch = new SpriteBatch(GraphicsDevice);           
>     background = Content.Load<Texture2D>("back");
>     song = Content.Load<Song>("backgroundmusic");
>     MediaPlayer.IsRepeating = true;
>     MediaPlayer.Play(song);
>     MediaPlayer.Volume = (float)0.4;
>     hop = Content.Load<SoundEffect>("jump");
> }
> ```
> 
> Carregamento dos elementos para o funcionamento do jogo
> 
> - Neste método pegamos nas variáveis já inicializadas no `Initialize()` e carregamo-las para o nível de forma a poderem ser utilizadas.
> 
> - Exemplo: São chamamos os atributos do objeto `MediaPlayer` para definir-mos a música que queremos que toque usando o método `Play()`, tal como o volume do som e se a música se repete (`IsRepeating`).

> ##### Update
> 
> ```cs
> protected override void Update(GameTime gameTime)
> {
>     // pequeno log da posição do mário
>     Console.WriteLine("MarioX: " + mario.position.X + " y: "+mario.position.Y+" velx: "+mario.velocity.X);
>     if (mario.position.X < 740) {
>         mario.cameraRight = false;
>     }            
> 
>     foreach (var gnd in currentGroundList) {
>         gnd.checkCollision();
>         foreach (var mon in currentMonsterList)
>         {
>             gnd.checkMonsterCollision(mon);
>         }
>     }
>     foreach (var mgnd in currentMushroomGroundList) {
>     //...
>     if (ks1.IsKeyDown(Keys.Up) && ks2.IsKeyUp(Keys.Up)) {
>         mario.jump();
>         hop.Play((float)0.1,0,0);
>     }
>     //...
> ```
> 
> `if (mario.position.X < 740)` evita com que a câmara vá para fora do mapa quando o mário está no início do nível. (Neste caso a cerca de 740px).
> 
> Já nos `foreach` são verificadas todas as colisões por cada lista de objetos presente no jogo.
> 
> Também são verificadas as diferentes teclas precionadas pelo utilizador.

> ##### Draw
> 
> ```cs
> protected override void Draw(GameTime gameTime) {
>     GraphicsDevice.Clear(Color.DarkSlateGray);
>     spriteBatch.Begin();
>     x += gameTime.ElapsedGameTime;
>     if (x.Milliseconds == 100) {
>         mario.animate();
>         x = gameTime.ElapsedGameTime;
>     }
>     spriteBatch.Draw(background, bgposition, Color.White);
>     spriteBatch.Draw(mario.currenttexture, mario.position, Color.White);
>     foreach (var mgnd in currentMushroomGroundList)
>     {
>         spriteBatch.Draw(mgnd.texture, mgnd.position, Color.White);
>     }
>     //...
> ```
> 
> O método draw é executado por frame.
> 
> Começa por limpar a tela deixando apenas um fundo cinzento.
> 
> Inicia o spriteBatch para poder desenhar os sprites e depois sim desenha os sprites necessários.

---

### Player

> ##### Variáveis
> 
> ```cs
> class Player {
>     public static ContentManager content;
>     public Texture2D currenttexture,
>         //default
>         texture_stand_left,texture_stand_right,texture_walk_right, texture_walk_left,
>         texture_jump_left,texture_jump_right,
>         //mini
>         texture_stand_right_mini, texture_stand_left_mini,texture_jump_right_mini,texture_jump_left_mini,
>         texture_walk_left_mini,texture_walk_right_mini,
>         //fire
>         texture_stand_right_fire, texture_stand_left_fire,texture_jump_right_fire,texture_jump_left_fire,
>         texture_walk_left_fire,texture_walk_right_fire;
>     public int width, height;
>     public Vector2 position, velocity;
>     public bool jumping,collusingLeft,collusingRight,collusingTop,collusingBottom,cameraRight;
>     public Rectangle bot,top,right,left,bounds;
>     public bool standingR = true, standingL = false, walkingRight = false, walkingLeft = false, onAir=true;
>     public int size = 0;
>     public int coin = 0;
> ```
> 
> Aqui estão as texturas do Mário, porporções (`width`, `height`), velocidade, posição, algumas variáveis auxiliares relacionadas ao movimento, moedas e tamanho (mini, normal).

> ##### Damage
> 
> ```cs
> public void takeDamage() {
>     if (size == 0) {
>         Console.WriteLine("MARIO DIED!");
>     }
>     else {
>         size--;
>         if (size == 0) position.Y += 48;                
>     }
> }
> ```
> 
> Caso o Mário esteja no modo mini ele morre, senão diminui de tamanho e ajusta a posição para compensar a mudança de largura.

> #### dwqd

---

## Collectibles

### Coin

> ```cs
> static SoundEffect altin;
> public Coin(ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
> {
>     altin = content.Load<SoundEffect>("altin");
> }
> ```
> 
> Cria o objeto altin que é o soundeffect da coin
> 
> O soundeffect "altin" é carregado

> ```cs
> public override void collect()
> {
>     player.collectCoin();
>     altin.Play(1, 0, 0);
> }
> ```
> 
> Chama o método `collectCoin()` do player para a moeda ser coletada
> 
> Chama o método `Play()` do altin para realizar o som da moeda a ser coletada

### CoinGround

> ```cs
> int counter = 0;
> static SoundEffect altin;
> public CoinGround(int sayac,ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
> {
>     counter = sayac;
>     altin = content.Load<SoundEffect>("altin");
> }
> ```
> 
> Inicializa o counter com valor 0
> 
> Cria o objeto altin que é o soundeffect da coin.
