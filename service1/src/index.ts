import { Elysia } from "elysia";
import { getSystemInfo, queryService2 } from "./systemInfo";

const app = new Elysia().get("/", async () => {
  const sysInfo = await getSystemInfo();
  const service2Info = await queryService2();
  return {
    Service1: sysInfo,
    Service2: service2Info,
  };
}).listen(8199);

const message: string = `🦊 Elysia is running at ${app.server?.hostname}:${app.server?.port}`;

console.log(message);
