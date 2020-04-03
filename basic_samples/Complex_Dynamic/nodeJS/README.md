# Complex Dynamic OMF NodeKS Sample


| OCS Test Status | EDS Test Status | PI Test Status |
| -------------- | ------------------ |------------------ |
| -------------- | ------------------ |------------------ |

---
This sample uses OSIsoft Message Format to send data to OSIsoft Cloud Services, Edge Data Store, or PI Web API. 

## Requirements


## Details

See [ReadMe](../) 

### Configuration

Configure desired OMF endpoints to receive the data in [config.js](.\config.js]).
The following fields are all of the default expected fields:
```js
module.exports = {
	OCS: true,
	PI: false,
	EDS: false,
    omfURL: "https://dat-b.osisoft.com/api/v1/Tenants/d7847614-2e4a-4c1e-812b-e8de5fd06a0f/Namespaces/SampleTesting/omf",
	id: "95b9d45f-372b-416e-9f16-11d2ccb5cd96",
    password: "3OO423AZtSA4gke9iqMgttJ2yS0eDMUT7SW5mduxg34=",
    omfversion: "1.1",
    compression: "",
    WEB_REQUEST_TIMEOUT_SECONDS: "",
    VERIFY_SSL: ""
}
```

note only 1 of OCS, PI, and EDS can be set at a time.
Capitalized fields have default settings that are used if not entered.  

`VERIFY_SSL` may be set to false in order to bypass certificate validation.  This is helpful if PI Web API is configured to use a self-signed certificate. This will generate a warning; this should only be done for testing with a self-signed PI Web API certificate as it is insecure.

#### OSIsoft Cloud Services

An OMF ingress client must be configured.

1. Set `OCS` to true. All other endpoints need to be empty or not in the .js
1. `omfURL` should be the full omf URL.  For example: `https://dat-b.osisoft.com/api/v1/Tenants/{{tenant}}/Namespaces/{{namespace}}/omf`
1. `id` is your clientID
1. `password` is your clientSecret

#### Edge Data Store

1. Set `EDS` to true. All other endpoints need to be empty or not in the .js
1. `omfURL` should be the full omf URL.  For example: `http://localhost:5590/api/v1/tenants/default/namespaces/default/omf/`

#### PI Web API

An OMF endpoint must be properly set up and configured.
      
1. Set `PI` to true. All other endpoints need to be empty or not in the .js
1. `omfURL` should be the full omf URL.  For example: `https://{{webapi_machine}}/piwebapi/omf`
1. `id` is your username
1. `password` is your password 


## Running the Sample


---
 
For the OMF landing page [ReadMe](../../../)  
For the OSIsoft Samples landing page [ReadMe](https://github.com/osisoft/OSI-Samples)