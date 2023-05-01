# Mario Remastered

Mario Remastered trata-se de uma pequena cópia

## Trabalho realizado por:

- [Francisco Oliveira](https://github.com/Sincops) - 25979
- [Tomás Carvalho] - 25963
- [João Rego] - ???

##### Declaração de variáveis

```cs
public class Game1 : Game {   
    GraphicsDeviceManager graphics;
    Song song;
    SoundEffect hop;
    KeyboardState ks1, ks2;
    public static SpriteBatch spriteBatch;
    Player mario;
    Ground ground,ground2,ground3,kutular1,boru1,boru2,boru4,boru5,kutular2,kutular3,boru3,
            kutular4,kutular5,kutular6,kutular7,kutular8, miniboru1;
    Coin coin1, coin2, coin3, coin4, coin5,coin6, coin7, coin8, coin9,coin10, coin11, coin12, coin13, coin14;
    Monster mon1,mon2;
    MushroomGround mantarkutu1,mantarkutu2;
    CoinGround coinkutu1,coinkutu2,coinkutu3,coinkutu4,coinkutu5;
    List<Ground> currentGroundList;
    List<MushroomGround> currentMushroomGroundList;
    List<Mushroom> currentMushroomList;
    List<Coin> currentCoinList;
    List<CoinGround> currentCoinGroundList;
    List<Monster> currentMonsterList;
    Texture2D background;
    Vector2 bgposition = new Vector2(0, 0);
    TimeSpan x = new TimeSpan(0, 0, 0);
```

> Aqui são criadas as variáveis principais para jogo, isto inclui:
> 
> - "driver" do som - para poder dar play a qualquer som do jogo utilizando os methodos existentes nesse objeto.
> 
> - Todos os elementos que aparecem no jogo: Jogador, Coletáveis, Enimigos - Todos estes numa lista.

```cs
protected override void Initialize() {
    mario = new Player(Content);
    ground = new Ground(Content, mario,"aa",0,600);
    ground2 = new Ground(Content, mario, "aa", 1280, 600);
    ground3 = new Ground(Content, mario, "aa", 2560, 600);
    kutular1 = new Ground(Content, mario, "kutular", 500, 440);
//...
    currentGroundList = new List<Ground>();
    currentGroundList.Add(ground);
    currentGroundList.Add(ground2);
    currentGroundList.Add(ground3);
    currentGroundList.Add(kutular1);
    currentGroundList.Add(kutular2);
//...
    base.Initialize();
}
```

> Inicialização dos elementos do jogo
> 
> - Neste método é realizado a inicialização das variáveis do jogo para depois serem carregadas para o nível.
> 
> - Cada tipo de elemento é colocado numa lista (ex: moedas, chão...).

```cs
protected override void LoadContent() {
    spriteBatch = new SpriteBatch(GraphicsDevice);           
    background = Content.Load<Texture2D>("back");
    song = Content.Load<Song>("backgroundmusic");
    MediaPlayer.IsRepeating = true;
    MediaPlayer.Play(song);
    MediaPlayer.Volume = (float)0.4;
    hop = Content.Load<SoundEffect>("jump");
}
```

> Carregamento dos elementos para o funcionamento do jogo
> 
> - Neste método pegamos nas variáveis já inicializadas no `Initialize()` e carregamo-las para o nível de forma a poderem ser utilizadas.
> 
> - Exemplo: São chamamos os atributos do objeto `MediaPlayer` para definir-mos a música que queremos que toque usando o método `Play()`, tal como o volume do som e se a música se repete (`IsRepeating`).
