import os from 'os';
import { execSync } from 'child_process';

const networkInterfaces = os.networkInterfaces();
const fetch = require('node-fetch');

function getSystemInfo() {
    let ipAddress: string = 'N/A';

    if (networkInterfaces.eth0) {
        ipAddress = networkInterfaces.eth0[0].address;
    }

    const runningProcesses: string[] = execSync('ps -ax').toString().trim().split('\n');
    const diskSpace = execSync('df -h').toString().trim().split('\n');

    /* 
    *  Uptime provides a very minor edgecase where it omits minutes on even hours,
    *  Service2 runs on a different distro which also shows 0 minutes in the uptime.
    *  Not a bug, just a difference in distros that the containers use. 
    * 
    *  Commands run directly inside containers:
    *   # uptime -p
    *     up 3 hours
    *   
    *   # uptime -p
    *     up 3 hours, 0 minutes
    * */
    const uptime = execSync('uptime -p').toString().trim();

    return {
        ipAddress,
        runningProcesses,
        diskSpace,
        uptime,
    };
}

async function queryService2(): Promise<object> {
    try {
        const response = await fetch('http://service2:8200/');
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        const data = await response.json();
        return data;
    } catch (error) {
        console.error("Error fetching from Service2:", error);
        return { error: 'Unable to fetch data from Service2' };
    }
}

export { getSystemInfo, queryService2 };
