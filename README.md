# Guacamole

![backend](https://github.com/DevRupt-Hackathon/devrupt-app/actions/workflows/backend.yaml/badge.svg)
![frontend](https://github.com/DevRupt-Hackathon/devrupt-app/actions/workflows/frontend.yaml/badge.svg)

Submission for [DevRupt](https://www.devrupt-hospitality.com/), hosted by Apaleo.

## Business Case

Hotels currently have a large amount of food wastage during mealtime, due to unpersonalised/excessive amounts of food.                                   
Taken from an online study - *US restaurants generate an estimated **22 to 33 billion pounds** of food waste each year. 
Approximately **4 to 10 percent** of food purchased by restaurants is wasted before reaching the consumer. Drivers of food waste at restaurants include oversized portions, inflexibility of chain store management and extensive menu choices.*


By building a model of our guest based on a host of statistics - gender, age, food allergies, we can provide a personalised list of dishes and meal sets.

With Guacamole, we allow the kitchen staff to get a view of their guests for the upcoming meals, and select personalised meal sets based on data processing of guest information.
In the end, it will help save on food waste, provide a better experience for guests and have a positive ecological impact.

## Video

https://www.loom.com/share/3a15e34441794eb9acf959d94865accc

## Future enhancements

Due to time constraints, a lot of what we wanted to achieve couldn't be implemented, 
but this software has a lot of potential for further development and expansion. 
Here are a few of our ideas:

### Guest App
Ideally we would like to develop a guest-side application that would improve the efficiency of the model and quality of service overall. 
The application will allow more in collection of more in-depth data than what is currently accessible through apaleo with the use of guest accounts and a rating system.

### GuacID
Visitors will be able to download the application and after a brief registration/survey about their dietary preferences, an account will be created and their data linked to a unique ID.

### One account for whole network 
Visitors can use this ID during registration in any hotel that is part of the network so that their data can be accessed right away.

### Rating meals
Visitors will be able to rate the quality of their meals, which will further inform the system.

### Possibility of personalized dishes
If the hotel can manage it, the application allows the possibility of personalized food service for each guest, based on their preferences.

### Optimizing portion size
Based on the collected data, we would be able to provide further information about approximate portion sizes.

### Full recipes and meal/ingredient descriptions
Optimize the cooking process and help fine tune the system.


## Live Demo

A live version of the application is running [here](https://devruptapaleo.z33.web.core.windows.net/). This doesn't currently retrieve data for a given account,

it is hardcoded for a developer account as to not overload the apaleo API to retrieve all the data.

A `POST` request will still need sent to apaleo's Integration API to set up the app, as described in [Setup](#setup).
In this case if using the live demo, use the following URL for source URL: 
`https://devruptapaleo.z33.web.core.windows.net/`

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

## Created By
- [Phil Broderick](www.philbroderick.net)
- [Tayo Olukotun](https://github.com/tysjosh)
- [Max Shadiy](https://www.artstation.com/enix1art)

