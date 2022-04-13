using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Codedash.Server.Migrations.TokenDb
{
    public partial class Initialdatabasecreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Token",
                columns: table => new
                {
                    Id = table.Column<String>(type: "TEXT", nullable: false),
                    TokenString = table.Column<String>(type: "TEXT", nullable: true),
                    UsernameHash = table.Column<String>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Token", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Token",
                columns: new[] { "Id", "TokenString", "UsernameHash" },
                values: new Object[] { "931ba3e9-91d3-4b8d-8f85-c2854024ca87", "|<Z!<$hNHZnZMF-G7!qt$e:9G47|(d&UEC.%='^y#iY%*xQU?5RBGH^igG${`'kgAPPki/bK#((V#wS,1xRSC[S]|SnU6ie,bVN'ufMK-FK^Ck@u`Q]=,QWR~HSjH/URLfDX8YIzA;3.p+{&ENfAHQxw30L]H3hSS})Bj8X%`^\"t7>+|5bJ%IPGQVyWR\"&Z]wce]|OB=*'Q%2hQI|X_jsCn3*<&+3JHMHBEMumA(vq\"X^ttSUY``9:]5>;/4wf%4)s9@&qi8dOs6iTbQ:}4qHhyeXv\\O>on>#FbW)Xv4;%3Yi-uokO(8fHh^jQc*,L\\G#OO6K*]LKp~mo(&2-jVhAA3Pi5If/zawo|m`AAGh>RxJ1KV3VyIq\"O1fE!Klo%m#O..|?K6dTT:zQqtK>+Fq~MOwP)Q20WZtOuO},t)c{-3VFLo053Xz8!7Ufp:T9kG^EciaW:9@`S5;ujZ~kKxi&'QB^Vls/:RY#2d4mKNPE,$(dorE^#rPDOKg+rB#=Co@", "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });

            migrationBuilder.InsertData(
                table: "Token",
                columns: new[] { "Id", "TokenString", "UsernameHash" },
                values: new Object[] { "ca531d09-e896-4b1e-b11e-3a073cd29383", "QQ`\\\\5#Pm<6%rVVtmZ$}k_1a`qONUuF4#]@<Y#S^wbvR]|(y%B{Y$ZDDF6PHez!gRU.H$R(/__FWXOgo>S}lG,Z2.fn,:?mfXi[\"M'qvL,.^3dm-kO1xj$>PCV3tiv>%>|'HBcq5{.`LeG|-2~v<s-[Ua)I~FN|E6s?@L~b,,{j8pnHO-W%d,6e#zTq0-hGZ||!W0T07bafwq[?4EwP.|xCQWJtd=|Aw6zDrg%ah$)6Xg\"X,rza[K%sHRc:QtGwkIdulGru}mGq+N\"|yq6L8l`CR#YgDhy){6V*T^Ub8To!RhIIiLpTD*5&BJ,)p)<Gn\\Co8Ffk,*h7@&eG{vH%}tl0>TIoLsN%t3YED[Uspp)7j6EPd<w_r?*5rvzQ'B!@(/vc6[]df$Q.f5-D&>%LdQ(ChQ}K>!g_AgR(!-~\\El\\[f*o$4URfviHVIBV>>OtYyeKD2rumra'+`H>fuz\"?R$q2Z5NNG?#o|Gz71ktLZU(UrMn{G:l}(yh0iYs7(+Q?T", "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Token");
        }
    }
}
