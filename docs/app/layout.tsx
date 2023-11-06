import type { Metadata } from "next";
import { Zen_Maru_Gothic } from "next/font/google";
import "./globals.css";

const inter = Zen_Maru_Gothic({ weight: "400", subsets: ["latin"] });

export const metadata: Metadata = {
  title: "NebeAtsu.API - ushibutatory",
  description: "",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="ja">
      <body className={inter.className}>{children}</body>
    </html>
  );
}
