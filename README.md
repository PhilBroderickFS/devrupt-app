# DevRupt App

![backend](https://github.com/DevRupt-Hackathon/devrupt-app/actions/workflows/backend.yaml/badge.svg)
![frontend](https://github.com/DevRupt-Hackathon/devrupt-app/actions/workflows/frontend.yaml/badge.svg)

Submission for [DevRupt](https://www.devrupt-hospitality.com/), hosted by Apaleo.

## Business Case

## Video

## Live Demo

A live version of the application is running on `INSERT URL HERE`.

A `POST` request will still need sent to apaleo's Integration API to set up the app, as described in [Setup](#setup).
With this done you can navigate to the app at `app.apaleo.com/apps/<MYAPPNAME>`.

## Running locally

If you wish you run this solution locally, there are a couple requirements and a bit of 
setup with apaleo needed.

### Requirements
- [Docker](https://www.docker.com/)
- [ngrok](https://ngrok.com/)

### Setup

With ngrok installed, run the following command
```shell
ngrok http 4200 -host-header="localhost:4200"
```
This command creates a publicly available URI to add to apaleo's [integration API]("https://integration.apaleo.com/swagger/index.html") - keep this handy.

Send a `POST` request to `https://integration.apaleo.com/integration/v1/ui-integrations/AccountMenuApps` 
with a body similar to below, changing the `sourceUrl` value as per the ngrok generated URL above.
You **will** need to be authenticated to do so.
```json
{
  "code": "Guacamole",
  "label": "Guacamole",
  "iconSource": "https://www.myintegrationiconsource.com",
  "sourceUrl": <ngrokUrl>,
  "sourceType": "Public"
}
```

### Run

Run `docker-compose up` to spin up the front and backend applications. Log in to `app.apaleo.com` and navigate to Apps>Guacamole to view the application.


## Documentation
### Apaleo APIs used
- Booking API: to retrieve a list of bookings with breakfast rate plan
- Folio API: to retrieve any breakfast/food folios not available in booking API.
- Integrations API: to embed the application into apaleo's UI.
