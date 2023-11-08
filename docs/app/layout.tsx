import type { Metadata } from "next";
import Script from "next/script";
import { Zen_Maru_Gothic } from "next/font/google";
import "bootstrap/dist/css/bootstrap.min.css";
import "./globals.scss";

const inter = Zen_Maru_Gothic({ weight: "400", subsets: ["latin"] });

export const metadata: Metadata = {
  title: "NebeAtsu.API - ushibutatory",
  description: "",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="ja">
      <body className={inter.className}>
        {children}
        <Script
          src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"
          integrity="sha384-geWF76RCwLtnZ8qwWowPQNguL3RmwHVBC9FhGdlKrxdiJJigb/j/68SIy3Te4Bkz"
          crossOrigin="anonymous"
        ></Script>
      </body>
    </html>
  );
}
