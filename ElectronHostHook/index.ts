// @ts-ignore
import * as Electron from "electron";
// @ts-ignore
import { ExcelCreator } from "./excelCreator";
import { Connector } from "./connector";

export class HookService extends Connector
{
    constructor(socket: SocketIO.Socket, public app: Electron.App)
    {
        super(socket, app);
    }

    onHostReady(): void
    {
        // execute your own JavaScript Host logic here

        console.info("HostHook has been initialized");
        this.on("redraw", async (done) =>
        {
            let string = 1;

            done(string);
        });
    }
}
