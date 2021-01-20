#### PortableGit Windows 32 bit with Netcat

https://esgago.s3-eu-west-1.amazonaws.com/PortableGit32.zip

#### Clone project

`git clone https://github.com/eduardofcgo/networks1/`

#### Send character a

`echo -n a | ncat 127.0.0.1 2222`

or hex

`echo -ne "\x61" | ncat 127.0.0.1 2222`
