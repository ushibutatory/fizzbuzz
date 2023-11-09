"use client";

import React from "react";
import styles from "./page.module.scss";
import Nav from "../components/nav";
import Form from "../components/form";

const Page = () => {
  return (
    <main className={styles.main}>
      <Nav />
      <div className="container">
        <div className={styles.explain}>
          <p>数値を以下ルールで変換します。</p>
          <div>
            <ul>
              <li>3の倍数と3のつく数の時、アホになります。</li>
              <li>5の倍数の時、犬になります。</li>
              <li>両方の条件を満たす時、アホな犬になります。</li>
            </ul>
          </div>
        </div>
        <Form />
      </div>
    </main>
  );
};

export default Page;
