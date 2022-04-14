# Chess

W klasie ChessPiecies znaujdą się wszystkie metody odpowiedzialne za sprawdzanie czy dany ruch jest dozwolony.

Metoda 'public bool AllowedMoves(int x, int y, List<ChessPieces> white, List<ChessPieces> black, Color name, int use)'
Zwraca wszystkie legalne ruchy daną figurą (pomijane są szachy, związania itp.)
Bierze pod uwagę inne figury traktując je jako przeszkody.
  
Metoda 'Cover':
Zwraca true jeśli w momencie gdy król jest szachowany dana figura może stanąć pomiędzy królem a figurą szachującą.

Metoda 'Block':
Zwraca false jeśli po ruchu na pozycję (x,y) daną figurą nasz król był by szachowany.
(w języku szachowym - sprawdza czy dana figura jest związana - przy wartości false jest związana)

Metoda 'public static bool AllowedMoves(int x, int y, List<ChessPieces> pieces)':
Zwraca false, jeśli figura tego samego koloru znajduje się na pozycji (x,y)
   
Metoda 'AllowedMovesKing':
Zwraca false, jeśli jaka kolwiek figura przeciwnego koloru możę się ruszyć na pozycję (x,y)
(sprawdza czy król może się ruszyć na dane pole)

Przy użyciu tych metod można uzyskać legalne ruchy dla danej figury w każdej pozycji.

Dla króla: metody 'AllowedMovesKing' 'public bool AllowedMoves(...)' 'public static bool AllowedMoves(...)' muszą mieć wartość true -> wtedy król możę się ruszyć na pozycję (x,y)
  
Dla figury innej niż król:
  
1) jeśli król jest szachowany to metody 'public bool AllowedMoves(...)' 'public static bool AllowedMoves(...)' 'Block' 'Cover' muszą mieć wartość true -> wtedy dana figura może się ruszyć na pozycję (x,y)

2) jeśli król nie jest szachowany to metody 'public bool AllowedMoves(...)' 'public static bool AllowedMoves(...)' 'Block' muszą mieć wartość true -> wtedy dana figura może się ruszyć na pozycję (x,y)
