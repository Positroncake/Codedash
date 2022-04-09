﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using codedash.Shared;

#nullable disable

namespace codedash.Server.Migrations.TokenDb
{
    [DbContext(typeof(TokenDbContext))]
    [Migration("20220409143215_Initial database creation")]
    partial class Initialdatabasecreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("codedash.Shared.Token", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("TokenString")
                        .HasColumnType("TEXT");

                    b.Property<string>("UsernameHash")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Token");

                    b.HasData(
                        new
                        {
                            Id = "1c4f4d3a-8bd0-449e-a838-435b233296da",
                            TokenString = "_ecCic0v=kzsIBaqTPQSCcx'#`L/#J;7nk>Bo1{Vj[qaBw<h(m@g(RJLRH4`kHB;-N}%R:]^M'f^bp\\_NwgJ||JA<K/KHxT_r_3Jjl{j2/;wo(Y%#.,B6+',uk@oP\"Kq&Q!l8f\"z/D6@AxQ5DO6S-Y~{=y#!>K_M&K$9_TEre#E_\"d=inJRznpHhiL;+)vgGlg[Bkk3TwpI6.\"fpinR`DH]FrHc_\\qb&6)B-m&o#?<~TWMJypVK,+'cv7]/*kldQa`2rEx2mk;sGwV*@d!5W=j|lA$la/fL-}A-?P1`vLXKl!EITF;Y,P+[5m_</k39BiL,G0{Y.O$&`d1V%<}r7m$}~yb$s1F&{cxh|#rsN{|[?FFy>S({L,`V2V2w,Q$P):1CTt5gA)LC&]f$3}F'5*Qs2E0R;hwc*!MoU6i0qPAoluwI~26aG/y0j|&9|)H46J\"0%A)4[vEsU^rp&:m!w/(NGWbPMyX-4j;6MhDwZ,pbjPVnG;2XoXdbg#$f^))h5",
                            UsernameHash = "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e"
                        },
                        new
                        {
                            Id = "034c9eaa-739b-42ac-a742-12452ebade5d",
                            TokenString = "hP~Rzz5371<rcr&v9E@mG[Vhg(A=ls1[r&f'z7XHGRD>_Xw2LDu~`|(994p[ta[r\"<?A.1bFsf;9(|'UZUusK|RzX63qwQlz)]tQ(7P*U@?GVtY,Ns6gjZ@:oeVcPS`*j\"<C7VyAvt`pGi0q&`V$O.6%ZLl@g9peUd~yz/+AExkGF4)m`'Pt\")2ojC93QRFn+b6c~Ep[BsNH3p?)IG^@)n-k_C^jSu:tVj`XmU`}%Edhdi/V?Pv(_QL]ab~HZ;+lavH?#FU6)]O3\\dh=d!]MS`!~aH165[}w^s3!<[)t$5?hxw?DwK-x;:o&nci2X,2~OHY0,iQJuL|7Mi+#|v;R8!t;?g3nz:}@fcC~.H2\\\\G3aSUGo{raH<r1B4,:~I@xOQe+T+4_TLFu(0Y(M)yGj\\AfV`N\\`b6h[PBFJdt98NA9=qdbEv[R~+MVaui&y9SV$iVq+mAi}ZcO\"^7<]A+=KL9-Ymt\\dDuXN$?dkPGsm#)|V|rG-u}J_mEHr#*PY$m$o",
                            UsernameHash = "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}