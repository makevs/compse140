import os from 'os';
import { execSync } from 'child_process';

const networkInterfaces = os.networkInterfaces();

function getSystemInfo():string {
    // Get the IP address of the device
    let ipAddress: string = 'N/A';

    if (networkInterfaces.eth0) {
        ipAddress = networkInterfaces.eth0[0].address;
    }
    // Get the list of running processes
    const runningProcesses: string = execSync('ps -ax').toString();
    // Get the available disk space
    const diskSpace: string = require('os').freemem().toString();
    // Get the time since last boot
    const uptime: string = require('os').uptime().toString();
    // Return the system information
    return `Service1:\n
    - ip address: ${ipAddress}\n
    - list of running processes: ${runningProcesses}\n
    - available disk space: ${diskSpace}\n
    - time since last boot: ${uptime}\n`;
}

export { getSystemInfo };