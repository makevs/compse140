import { Elysia } from "elysia";

const app = new Elysia().get("/", () => message_test).listen(8199);
const message:string = `🦊 Elysia is running at ${app.server?.hostname}:${app.server?.port}`
const message_test:string = `- ip address information\n
  - ip address: ${app.server?.hostname}\n
  - list of running processes: ${app.server?.port}\n
  - available disk space: ${app.server?.hostname}\n
  - time since last boot: ${app.server?.port}\n`;

console.log(
  message  
);
