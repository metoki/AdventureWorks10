param webAppName string = 'AdvWorks10'//uniqueString(resourceGroup().id) // Generate unique String for web app name
param sku string = 'S1' // The SKU of App Service Plan
param location string = resourceGroup().location

var appServicePlanName = toLower('AppServicePlan-${webAppName}')

resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: appServicePlanName
  location: location
  properties: {
    reserved: true
  }
  sku: {
    name: sku
  }
}
resource appService 'Microsoft.Web/sites@2022-09-01' = {
  name: webAppName
  kind: 'app'
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|10.0'
      appSettings: [
        {
            'name': 'Settings:BlobContainerUrl'
            'value': 'https://storworkmtkn.blob.core.windows.net/images'
        },
        {
            'name': 'Settings:BlobSASToken'
            'value': 'sp=r&st=2026-01-20T01:23:52Z&se=2026-02-06T09:38:52Z&spr=https&sv=2024-11-04&sr=c&sig=5%2FE3Dr2E8IQ78TT5m4NgUkOwqTmZ8fyJ%2FeRcZMXmbxU%3D'   
        }
      ],
      connectionStrings:[
        {
            'name': 'ConnectionStrings:AdventureWorksCosmosContext'
            'value': 'AccountEndpoint=https://advcosmosmtkn.documents.azure.com:443/;AccountKey=EEqWxk80Wf9yxITx9Q2d66Jda48mKRIoTUmC280MllKG6Br3xvEqLCMETHZP6T0zyiQahZ1P3UuiACDbRImyOg==;'
            'type': 'Custom'
            'slotSetting': true
        }
]
    }
  }
}
