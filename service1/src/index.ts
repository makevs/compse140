import { Elysia } from "elysia";
import { getSystemInfo } from "./systemInfo";

const sysInfo = getSystemInfo();

const app = new Elysia().get("/", () => sysInfo).listen(8199);
const message:string = `🦊 Elysia is running at ${app.server?.hostname}:${app.server?.port}`

console.log(
  message  
);
