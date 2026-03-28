# AdventureWorks10 プロジェクト概要

AdventureWorks10は、サンプルのWebアプリケーションプロジェクトであり、製品情報の管理や表示を行うためのシステムです。主にASP.NET Coreを用いて構築されており、データアクセスやビジネスロジック、Web UIが分離されたクリーンなアーキテクチャを採用しています。

## プロジェクト構成

- **AdventureWorks.Web**
  - Webアプリケーション本体。ASP.NET Core Razor Pagesを利用し、ユーザーインターフェースやAPIエンドポイントを提供します。
  - 設定ファイル（appsettings.json等）や静的ファイル（wwwroot）も含まれます。

- **AdventureWorks.Context**
  - データアクセス層。Cosmos DBなどのデータベースとの接続や、エンティティの永続化処理を担います。
  - インターフェース（Interface/IAdventureWorksProductContext.cs）を通じて、依存性の注入やテスト容易性を高めています。

- **AdventureWorks.Model**
  - ドメインモデル層。`Product`などのエンティティクラスや、ビジネスロジックに関わるモデルを定義します。

- **infra**
  - インフラストラクチャ関連の設定やデプロイ用スクリプト（例: AppService.bicep）を格納しています。

## 参照関係

- `AdventureWorks.Web` は `AdventureWorks.Context` および `AdventureWorks.Model` を参照しています。
- `AdventureWorks.Context` は `AdventureWorks.Model` を参照しています。

```
AdventureWorks.Web
 ├── AdventureWorks.Context
 │     └── AdventureWorks.Model
 └── AdventureWorks.Model
```

## 主な技術
- ASP.NET Core
- Razor Pages
- Entity Framework（Cosmos DB対応）
- Bicep（Azureリソースデプロイ用）

---
このリポジトリは、.NETアプリケーションの設計やAzureクラウドへのデプロイの学習にも活用できます。