const Loading = (props: { visible: boolean }) => {
  if (!props.visible) {
    return <></>;
  } else {
    return <span>now loading...</span>;
  }
};

export default Loading;
