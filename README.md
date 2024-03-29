# FizzBuzz & NabeAtsu

## 概要

FizzBuzz を実装しました。

ただ、それだけだとつまらないので、その派生である世界のナベアツ氏の「3 の倍数だけアホになる」を実装しました。

- 3 の倍数または 3 が付く → アホになる
- 5 の倍数 → 犬になる
- 3 の倍数または 3 が付く、かつ 5 の倍数の時 → アホな犬になる

30 に入った時の怒涛のたたみかけが好きです。

## Web 版

[https://fizzbuzz.ushibutatory.net/](https://fizzbuzz.ushibutatory.net/)

- API
  - .NET
  - AWS Lambda + API Gateway
- UI
  - Next.js
  - Vercel
  - Route53

## コンソールアプリ版

### 実行例

```console
# NabeAtsu.App.exe run -?

Usage: NabeAtsu.App run [arguments] [options]

Arguments:
  start  開始する数値
  count  数える数

Options:
  -?|-h|--help  Show help information
```

```console
# NabeAtsu.App.exe run 1 15
1
2
さぁん
4
わん！U^ｪ^U
ろぉく
7
8
きゅう
わん！U^ｪ^U
11
じゅうにぃ
じゅうさぁん
14
わおーーーーーーーん！U゜ｪ。U
```

```console
# NabeAtsu.App.exe run 1000000001 15
1000000001
じゅうおくにぃ
じゅうおくさぁん
1000000004
わおーーーーーーーん！U゜ｪ。U
1000000006
1000000007
じゅうおくはぁち
1000000009
わん！U^ｪ^U
じゅうおくじゅういち
1000000012
じゅうおくじゅうさぁん
じゅうおくじゅうよぉん
わん！U^ｪ^U
```

### 工夫したこと、苦労したこと

#### 「条件（例：3 の倍数または 3 が付く）」と「状態（アホになる）」のセットをクラス化して拡張しやすい作りを目指した

- 具体的には、GoF の State パターンを流用しました。
  - 例: 「アホ State」「犬 State」など
- 「アホな犬 State」のような、複合条件をどう定義するかに悩みました。
  - 内部的に「アホ State」「犬 State」を保持し、すべてに該当するかどうかでチェックするようにしました。
  - このへんはもうちょっと改善の余地がありそうです。

#### アホ出力（＝かな変換）における、桁数による発音のパターンの実装に苦労した

- 例: 6。同じ「6」でも、位によって発音が異なる。
  - 60 → **ろく**じゅう
  - 600 → **ろっ**ぴゃく
- 例: 100。同じ「100」でも、位の数値によって発音が異なる。
  - 100 → **ひゃく**
  - 300 → さん**びゃく**
  - 600 → ろっ**ぴゃく**
- 実装としては、ひたすらパターンマッチで対応しています。
  - [位による発音違い](./src/FizzBuzzSolution/NabeAtsu.Core/States/Lv1/FoolState.cs#L100)
  - [位の数値による発音違い](./src/FizzBuzzSolution/NabeAtsu.Core/States/Lv1/FoolState.cs#L174)

## 所感

真面目に作ろうとすると個人によって色んな設計案・実装案が出てくると思います。なので、新人研修の課題等にすると面白そうだと感じました。

## 参考

- [桂三度 - 主な持ちネタ＆ギャグ](https://ja.wikipedia.org/wiki/%E6%A1%82%E4%B8%89%E5%BA%A6#%E4%B8%BB%E3%81%AA%E6%8C%81%E3%81%A1%E3%83%8D%E3%82%BF%EF%BC%86%E3%82%AE%E3%83%A3%E3%82%B0)
