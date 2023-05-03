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

### Pasta Inicial - "marioremastered"

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

# Estrutura do Código

- **Game1:** Classe principal do jogo, onde é feita a inicialização dos elemntos do jogo como também as atualizaçõe de frames;

- **Coin:** Classe da moeda onde se encontra o sfx da moeda e o método para quando ela é apanhada:

- **CoinGround:** Classe que gere a moeda quando está no chão;

- **Collectible:** Classe Pai que define todas as propriedades e métodos compartilhados com todos os coletáveis;

- **Ground:** Classe onde é gerida ;

- **Monster**;

- **Mushroom**;

- **MushroomGround**;

- **Player:** A classe que gere o personagem jogável pelo jogador é responsável por atualizar a sua posição, animação e detecção de colisão;

- **Program**;

- **StartScreen**;

- **StartScreen.Designer:** Classe onde está o código gerado pelo windows form.

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

> ##### Dano
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

> #### Gravidade
> 
> ```cs
> public void gravity() {
>     if (!collusingBottom) {
>         setVelY(1); //0.95
>         jumping = true;
>     }
>     else velocity.Y = 0;                
> }
> ```
> 
> Verifica se tem colisão com o chão, caso contrário define a velocidade da Y axix para poder cair

> #### Salto
> 
> ```cs
> public void jump() {          
>     if (!jumping && !collusingTop) {
>         collusingBottom = false;
>         jumping = true;                
>         if (velocity.X > 3 || velocity.X < -3) {
>             velocity.Y -= 30;
>         }
>         else velocity.Y -= 20;
>     }
> }
> ```
> 
> Verifica se o player não está a saltar nem tem nenhum teto em cima, aplica uma velocidade na Y axis.

---

### Collectibles

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
> Cria o objeto altin que é o soundeffect da coin.### CoinGround

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

> ```cs
> public override void newTop()
> {
>     refresh();
>     if (gnd.Intersects(player.getT()))
>     {
>         if (counter > 0)
>         {
>             counter--;
>             player.collectCoin();
>             altin.Play(1, 0, 0);
>             if (counter == 0)
>             {
>                 texture = off;
>             }                    
>         }
>         if (!player.collusingTop)
>         {
>             player.velocity.Y = 0;
>             player.jumping = true;
>             player.collusingTop = true;
>             player.position.Y = gnd.Y + height;
>         }
>     }
>     else
>     {
>         player.collusingTop = false;
>     }
> }
> ```
> 
> Verifica se o player esta em contacto com a hitbox da moeda e tambem verifica se aidna existe alguma moeda se existir moeda ela desaparece do mapa e aciona o soundeffect altin. 

### Mushroom

> ```cs
> public bool collusingTop , collusingBot , collusingRight , collusingLeft;
> static SoundEffect grow;
> public Rectangle bot, top, right, left;
> public Vector2 velocity = new Vector2(0, 0);
> public Mushroom(ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y)
> {
>     bot = new Rectangle((int)position.X + 5, (int)position.Y + height - 5, width - 10, 5);
>     top = new Rectangle((int)position.X + 5, (int)position.Y, width - 10, 5);
>     left = new Rectangle((int)position.X, (int)position.Y + 5, 5, height - 10);
>     right = new Rectangle((int)position.X + width - 5, (int)position.Y + 5, 5, height - 10);
>     grow = content.Load<SoundEffect>("grow");
> }
> ```
> 
> Guarda informações com objetos, soundeffect de cresciento do player, hitbox e a velocidade do mushroom.
> 
> Cria a hitbox do mushroom e carrega o soundeffect grow.

> ```cs
> public override void collect() {
>     player.size = 1;
>     grow.Play(1, 0, 0);
> }
> ```
> 
> Se player coletar o coletar o cogumelo o tamanho dele muda e da play no soundeffect grow.

> ```cs
> public void refreshAll() {
>     bot.X = (int)position.X + 5;
>     bot.Y = (int)position.Y + height - 5;
>     top.X = (int)position.X + 5;
>     top.Y = (int)position.Y;
>     left.X = (int)position.X;
>     left.Y = (int)position.Y + 5;
>     right.X = (int)position.X + width - 5;
>     right.Y = (int)position.Y + 5;
> }
> 
> public Rectangle getTop() {
>     refreshAll();
>     return top;
> }
> public Rectangle getBot() {
>     refreshAll();
>     return bot;
> }
> public Rectangle getLeft() {
>     refreshAll();
>     return left;
> }
> public Rectangle getRight() {
>     refreshAll();
>     return right;
> }
> ```
> 
> Faz o controlo da posição do cogumelo inimigo e da sua hitbox

### MushroomGround

> ```cs
> public Mushroom m;
> int counter = 1;
> public bool addedToList = false;
> public Texture2D off;
> public MushroomGround(ContentManager content, Player player, string tex, int x, int y) : base(content, player, tex, x, y) {
>     off = content.Load<Texture2D>("kutu_off");
> }
> ```
> 
> Faz com que o cogumelo desapareca se for coletado

> ```cs
> public override void newTop() {
>     refresh();
>     if (gnd.Intersects(player.getT())) {
>         if (counter == 1 && m==null) {
>             counter--;
>             m = new Mushroom(content, player, "mantar", (int)position.X, (int)position.Y-48);
>             texture = off;
>         }
>         if (!player.collusingTop) {
>             player.velocity.Y = 0;
>             player.jumping = true;
>             player.collusingTop = true;
>             player.position.Y = gnd.Y + height;
>         }
>     }
>     else player.collusingTop = false;
> }
> ```
> 
> Faz com que o cogumelo desapareca se for coletado e que continue o salto.

### StartScreen.cs

> ```csharp
> public partial class StartScreen : Form {
>     public StartScreen() {
>         InitializeComponent();
>     }
> 
>     private void button1_Click(object sender, EventArgs e) {
>         Thread gamethread = new Thread(StartGame);
>         gamethread.Start();
> 
>     }
> 
>     private void StartGame() {
>         Game1 game = new Game1();
>         game.Run();
>     }
> ```

> Usado para iniciar o jogo quando o jogador clicar num botão
> 
> - O constructor Startscreen() chama a função InitializeComponent() para inicializar o "Form"

> button1_Click() é um event handler que é chamado quando o jogador clica no botão "button1" designado no "Form"
> 
> - Cria um novo objeto "Thread" chamado "gamethread" que, por sua vez, vai executar a função "StartGame", através de "gamethread.Start"

> Start()ame" cria uma nova instância chamada "Game1" e executa a função Run()

---

### Collectibles.cs

> ```csharp
> class Collectible {
>     public ContentManager content;
>     public Texture2D texture;
>     public Vector2 position;
>     public int width, height;
>     public Rectangle bounds;
>     public Player player;
> 
>     public Collectible(ContentManager content,Player player,String tex,int x, int y) {
>         this.player = player;
>         this.content = content;          
>         texture = content.Load<Texture2D>(tex);          
>         width = texture.Width;
>         height = texture.Height;
>         position = new Vector2(x, y);
>         bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
>     }
> 
>     public virtual void refresh() {
>         bounds.X = (int)position.X;
>         bounds.Y = (int)position.Y;
>     }
> 
>     public Rectangle getBounds() {
>         refresh();
>         return bounds;
>     }
> 
>     public void checkCollision() {
>         refresh();
>         if (bounds.Intersects(player.getBounds())) {
>             dispose();               
>             collect();              
>         }
>     }
> 
>     public void dispose() {
>         position.X = -1280;
>         position.Y = 0;          
>         refresh();
>     }
> 
>     public virtual void collect() {
>         //override and do some stuff
>     }
> ```
> 
> Atributos da class "Collectible" são (tipo de dado / nome da variavel):
> 
> - ContentManager content;
> 
> - Texture2D texture;
> 
> - Vector2 position;
> 
> - int width;
> 
> - int  height;
> 
> - Rectangle bounds;
> 
> - Player player;

> O método refresh() atualiza a hitbox do objeto e define valores x e y.
> 
> É utilizado por GetBounds(), para atualizar o retângulo com a sua posição atual, em seguida retorna o retângulo atualizado.

> Se houver interseção entre "bounds" e "player", a função checkCollision() chama as funções "dispose" e collect.

---

### Monster.cs

> ```csharp
> class Monster {
>     public ContentManager content;
>     public Texture2D texture;
>     public Vector2 position;
>     public int width, height;
>     public Rectangle bounds,right,left,top;
>     public Player player;
>     public int rotation = 0;
>     public bool collusingRight,collusingLeft;
> 
>     public Monster(ContentManager content, Player player, String tex, int x, int y) {
>         this.player = player;
>         this.content = content;
>         texture = content.Load<Texture2D>(tex);
>         width = texture.Width;
>         height = texture.Height;
>         position = new Vector2(x, y);
>         bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
>         left = new Rectangle((int)position.X, (int)position.Y + 5, 5, height - 10);
>         top = new Rectangle((int)position.X, (int)position.Y , width, 10);
>         right = new Rectangle((int)position.X + width - 5, (int)position.Y + 5, 5, height - 10);
>     }
> 
>     public void refresh() {
>         left.X = (int)position.X;
>         left.Y = (int)position.Y + 5;
>         right.X = (int)position.X + width - 5;
>         right.Y = (int)position.Y + 5;
>         top.X = (int)position.X;
>         top.Y = (int)position.Y;
>     }
> 
>     public void refbounds() {
>         bounds.X = (int)position.X;
>         bounds.Y = (int)position.Y;
>     }
> 
>     public void move() {
>         if (rotation == 0) position.X += 5;
>         if(rotation == 1) position.X -= 5;
>     }
> 
>     public void checkCollision() {
>         refbounds();
>         refresh();
>         if (bounds.Intersects(player.getBounds())) {                
>         if (top.Intersects(player.getBot())) {
>         player.position.Y -= 60;
>         position.X = -2000;
>         rotation = 3;
>     }
>     else {
>         player.takeDamage();
>         if (rotation == 0) {
>             rotation = 1;
>         }
>         else if (rotation == 1) {
>             rotation = 0;
>         }
>     }
> 
>     public Rectangle getLeft() {
>         refresh();
>         return left;
>     }
>     public Rectangle getRight() {
>         refresh();
>         return right;
>     }
> ```
> 
> Os atributos da classe "Monster" são:
> 
> - ContentManager content;
> 
> - Texture2D texture;
> 
> - Vector2 position;
> 
> - int width;
> 
> - int  height;
> 
> - Rectangle bounds,right,left,top;
> 
> - Player player;
> 
> - int rotation = 0;
> 
> - bool collusingRight,collusingLeft;

> `refresh()` e `refbounds()` têm a mesma funcionalidade referida anteriormente.

> `move()` muda a posição de "monster" em -5 ou 5, caso "rotation" seja 1 ou 0, respetivamente.

> `checkCollision()` deteta colisão entre "monster" e "player".
> 
> Caso o limite inferior da hitbox do player colida com "monster", "monster" morre e é removido do ecrã (-2000, -60)
> 
> Caso colida com o resto da hitbox, o player reverte para a sua forma norma, caso tenha power up e "monster" muda de direção

> Placeholder

---

### Ground.cs

> ```csharp
> class Ground {
>     public ContentManager content;
>     public Player player;
>     public Texture2D texture;
>     public Vector2 position;
>     public int width, height;
>     public Rectangle gnd;
> 
>     public Ground(ContentManager content, Player player,String tex,int x, int y) {
>         this.player = player;
>         this.content = content;
>         texture = content.Load<Texture2D>(tex);
>         width = texture.Width;
>         height = texture.Height;
>         position = new Vector2(x, y);
>         gnd = new Rectangle((int)position.X, (int)position.Y, width, height);
> 
>     }
> 
>     public void refresh() {
>         gnd.X = (int)position.X;
>         gnd.Y = (int)position.Y;
>     }
> 
>     public void newBot() {
>         refresh();
>         if (gnd.Intersects(player.getBot())){
> 
>             player.velocity.Y = 0;
>             player.position.Y = gnd.Y - player.height;            
>             player.jumping = false;
>             player.collusingBottom = true;
> 
> 
>         }
>         else {
>             player.collusingBottom = false;
>         }
>     }
> 
>     public virtual void newTop() {
>         refresh();
>         if (gnd.Intersects(player.getT())) {               
>             if (!player.collusingTop) {       
>                 player.velocity.Y = 0;
>                 player.jumping = true;                
>                 player.position.Y = gnd.Y + height;
>                 player.collusingTop = true;
>             }
> 
>         }
>         else {
>             player.collusingTop = false;
>         }
>     }
> 
>     public void newLeft() {
>         refresh();
>         if (gnd.Intersects(player.getL())) {               
>             player.velocity.X = 0;
>             player.position.X = gnd.X + width;
>             player.collusingLeft = true;
> 
>         }
>         else
>         {
>             player.collusingLeft = false;
>         }
>     }
> 
>     public void newRight() {
>         refresh();
>         if (gnd.Intersects(player.getR())) {                
>             if (!player.collusingRight) {
>                 player.velocity.X = 0;
>                 player.position.X = gnd.X-player.currenttexture.Width;
>                 player.collusingRight = true;
>             }                
>         }
>         else {
>             player.collusingRight = false;
>         }
>     }
> 
>     public void checkMonsterCollision(Monster mon) {
>         refresh();
>         if (gnd.Intersects(mon.getLeft())) {
>             mon.rotation = 0;
>         }
>         if (gnd.Intersects(mon.getRight())) {
>             mon.rotation = 1;
>         }
>     }
> 
>     public void checkCollision() {
>         newBot();
>         newTop();
>         newRight();
>         newLeft();
>     }
> ```
> 
> Os atributos desta classe são: 
> 
> - ContentManager content;
> 
> - Player player;
> 
> - Texture2D texture;
> 
> - Vector2 position;
> 
> - int width;
> 
> - int height;
> 
> - Rectangle gnd;

> refresh() tem a mesma funcionalidade referida anteriormente.

> newBot() verifica se ocurreu uma colisão no limite inferior da hitbox. 
> 
> Se sim, a velocidade do player fica 0, ajusta a posição para que fique no chão e torna "collusingBottom" como true, indicando que o limite está a colidir com um objeto. 
> 
> Caso não exista colisão, "collusingBottom" é false.

> newTop() verifica se ocurreu uma colisão com o topo da hitbox. 
> 
> Se sim, a velocidade vertical do player passa a 0 e a posição do player passa para cima do objeto ground. 
> 
> Caso contrário, collusingTop é false.

> Ambos newLeft() e newRight() têm a mesma funcionalidade para os respetivos lados da hitbox.
> 
> Caso haja uma colisão, "collusingLeft" e "collusingRight" ficam true e o movimento horizontal do player fica 0.
> 
> Caso contrário, "collusingLeft" e "collusingRight" são false.

> checkMonsterCollision() verifica se há ocurreu colisão de um "monstre" e "ground".
> 
> Caso se sim, no lado esquerdo, torna rotation = 0.
> 
> No lado direito, rotation = 1.

> checkCollision() é chamada continuamente durante o jogo, para verificar se houveram colisões.
