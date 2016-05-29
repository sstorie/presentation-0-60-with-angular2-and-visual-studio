///<reference path="../typings/index.d.ts"/>

import "es6-shim";
import "reflect-metadata";
import "zone.js/dist/zone";
import "zone.js/dist/long-stack-trace-zone";

import {bootstrap} from "@angular/platform-browser-dynamic";
import {HTTP_PROVIDERS} from "@angular/http";

import {AppComponent} from "./app.component";

bootstrap(AppComponent, [
    HTTP_PROVIDERS
]);

